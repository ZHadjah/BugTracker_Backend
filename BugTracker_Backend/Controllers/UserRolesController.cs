using BugTracker_Backend.Data;
using BugTracker_Backend.Extensions;
using BugTracker_Backend.Models;
using BugTracker_Backend.Models.ViewModels;
using BugTracker_Backend.Services;
using BugTracker_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRolesController : Controller
    {
        private readonly IBTRolesService _rolesService;
        private readonly IBTCompanyInfoService _companyInfoService;
        private readonly ApplicationDbContext _context;


        public UserRolesController(IBTRolesService rolesService, IBTCompanyInfoService companyInfoService, ApplicationDbContext context)
        {
            _rolesService = rolesService;
            _companyInfoService = companyInfoService;
            _context = context;
        }

        // GET: UserRoles/NumberOfUsers
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> NumberOfUsers()
        {
            var applicationDbContext = await _context.Users.Select(s => s).ToListAsync();
            int numberOfUsers = applicationDbContext.Count();

            return Ok(numberOfUsers);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ManageUserRoles()
        {
            List<ManageUserRolesViewModel> model= new();

            int companyId = User.Identity.GetCompanyId().Value;

            List<BTUser> users = await _companyInfoService.GetAllMembersAsync(companyId);

            foreach (BTUser user in users)
            {
                ManageUserRolesViewModel viewModel = new();
                viewModel.BTUser = user;
                IEnumerable<string> selected = await _rolesService.GetUserRolesAsync(user);
                viewModel.Roles = new Microsoft.AspNetCore.Mvc.Rendering.MultiSelectList(await _rolesService.GetRolesAsync(), "Name", "Name", selected);
                
                model.Add(viewModel);
            }

            return Ok(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel member)
        {
            //gget company id
            int companyId = User.Identity.GetCompanyId().Value;

            //instantiate BTUser
            BTUser btUser = (await _companyInfoService.GetAllMembersAsync(companyId)).FirstOrDefault(u => u.Id == member.BTUser.Id);

            //Get roles for user
            IEnumerable<string> roles = await _rolesService.GetUserRolesAsync(btUser);

            //Grab selected role
            string userRole = member.selectedRoles.FirstOrDefault();

            if(!string.IsNullOrEmpty(userRole))
            {
                //remove user from their roles
                if(await _rolesService.RemoveUserFromRolesAsync(btUser, roles)) 
                {
                    //add user to the new role
                    await _rolesService.AddUserToRoleAsync(btUser, userRole);
                }
            }

            //navigate back to the view
            return RedirectToAction(nameof(ManageUserRoles));
        }
    }
}
