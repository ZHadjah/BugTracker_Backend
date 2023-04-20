using BugTracker_Backend.Services.Interfaces;
using BugTracker_Backend.Models.Enums;
using NuGet.Packaging;
using BugTracker_Backend.Models;

namespace BugTracker_Backend.Services
{
    public class BTDropDownOptionsService : IBTDropDownOptionsService
    {
        public List<string> GetAllTicketStatusesAsync()
        {
            List<string> ticketStatuses = new List<string>();

            ticketStatuses = 
                Enum.GetValues(typeof(BTTicketStatus))
                    .Cast<BTTicketStatus>()
                    .Select(v => v.ToString())
                    .ToList();

            return ticketStatuses;
        }

        public List<string> GetAllTicketTypesAsync()
        {
            List<string> ticketTypes = new List<string>();

            ticketTypes =
                Enum.GetValues(typeof(BTTicketType))
                    .Cast<BTTicketType>()
                    .Select(v => v.ToString())
                    .ToList();

            return ticketTypes;
        }

        public List<string> GetAllTicketPrioritiesAsync()
        {
            List<string> ticketPriorities = new List<string>();

            ticketPriorities =
                Enum.GetValues(typeof(BTTicketPriority))
                    .Cast<BTTicketPriority>()
                    .Select(v => v.ToString())
                    .ToList();

            return ticketPriorities;
        }
    }
}
