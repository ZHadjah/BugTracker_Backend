﻿using BugTracker_Backend.Data;
using BugTracker_Backend.Extensions;
using BugTracker_Backend.Models;
using BugTracker_Backend.Models.ViewModels;
using BugTracker_Backend.Services;
using BugTracker_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Configuration;
using System.ComponentModel.Design;
using System.Security.Claims;

namespace BugTracker_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserRolesController : Controller
    {
        private readonly IBTRolesService _rolesService;
        private readonly IBTCompanyInfoService _companyInfoService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BTUser> _userManager;

        public UserRolesController(IBTRolesService rolesService,
                                   IBTCompanyInfoService companyInfoService,
                                   ApplicationDbContext context,
                                   UserManager<BTUser> userManager)
        {
            _rolesService = rolesService;
            _companyInfoService = companyInfoService;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsersInCompany()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            BTUser user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            int companyId = user.CompanyId.Value; 

            List <BTUser> usersInCompany = await _companyInfoService.GetAllMembersAsync(companyId);

            string jsonResult = JsonConvert.SerializeObject(usersInCompany, Formatting.Indented);

            return Ok(jsonResult);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ManageUserRoles()
        {
            List<ManageUserRolesViewModel> model = new List<ManageUserRolesViewModel>();

            int companyId = User.Identity.GetCompanyId().Value;

            List<BTUser> usersInCompany = await _companyInfoService.GetAllMembersAsync(companyId);

            foreach (BTUser user in usersInCompany)
            {
                ManageUserRolesViewModel viewModel = new ManageUserRolesViewModel();
                viewModel.BTUser = user;
                //IEnumerable<string> selected = await _rolesService.GetUserRolesAsync(user);

                // Find the role of the current user and put it into the variable assignedRole
                var roles = await _userManager.GetRolesAsync(user);
                string assignedRole = roles.FirstOrDefault();

                viewModel.usersRole = assignedRole ?? "N/A";

                //viewModel.Roles = new Microsoft.AspNetCore.Mvc.Rendering.MultiSelectList(await _rolesService.GetRolesAsync(), "Name", "Name", selected);

                model.Add(viewModel);
            }

            return Ok(model);
        }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    [Route("[action]")]
    //    public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel member)
    //    {
    //    //    //gget company id
    //    //    int companyId = User.Identity.GetCompanyId().Value;

    //    //    //instantiate BTUser
    //    //    BTUser btUser = (await _companyInfoService.GetAllMembersAsync(companyId)).FirstOrDefault(u => u.Id == member.BTUser.Id);

    //    //    //Get roles for user
    //    //    IEnumerable<string> roles = await _rolesService.GetUserRolesAsync(btUser);

    //    //    //Grab selected role
    //    //    //string userRole = member.selectedRoles.FirstOrDefault();

    //    //    if(!string.IsNullOrEmpty(userRole))
    //    //    {
    //    //        //remove user from their roles
    //    //        if(await _rolesService.RemoveUserFromRolesAsync(btUser, roles)) 
    //    //        {
    //    //            //add user to the new role
    //    //            await _rolesService.AddUserToRoleAsync(btUser, userRole);
    //    //        }
    //    //    }

    //    //    //navigate back to the view
    //    //    return RedirectToAction(nameof(ManageUserRoles));
    //    //}
    }
}
