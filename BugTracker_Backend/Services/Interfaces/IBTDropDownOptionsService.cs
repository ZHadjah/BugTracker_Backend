using BugTracker_Backend.Models;
using BugTracker_Backend.Models.Enums;

namespace BugTracker_Backend.Services.Interfaces
{
    public interface IBTDropDownOptionsService
    {
        public string GetAllTicketStatusesAsync();

        public string GetAllTicketTypesAsync();

        public  string GetAllTicketPrioritiesAsync();


    }
}
