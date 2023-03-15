using BugTracker_Backend.Models.Enums;
using BugTrackerBackend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace BugTracker_Backend.Services.Interfaces
{
    public interface IBTDashboardInfoService
    {
        public Task<string> GetDashboardNumbers();
    }
}
