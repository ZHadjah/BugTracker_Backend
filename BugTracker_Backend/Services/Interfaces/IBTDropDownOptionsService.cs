using BugTracker_Backend.Models;

namespace BugTracker_Backend.Services.Interfaces
{
    public interface IBTDropDownOptionsService
    {
        public List<string> GetAllTicketStatusesAsync();

        public List<string> GetAllTicketTypesAsync();

        public List<string> GetAllTicketPrioritiesAsync();


    }
}
