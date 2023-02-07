using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTracker_Backend.Models.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public BTUser BTUser { get; set; }
        public MultiSelectList Roles { get; set; }
        public List<string> selectedRoles { get; set; }
    }

       
}
