using BugTracker_Backend.Models;

namespace BugTracker_Backend.Services.Interfaces
{
    public interface IBTNotification
    {
        public Task AddNotificationAsync(Notification notification);

        public Task<List<Notification>> GetRecievedNotificationsAsync(string userId);

        public Task<List<Notification>> GetSentNotificationAsync(string userId);

        public Task<bool> SendEmailNotificationAsync(string userId);

        public Task SendEmailNotificationsByRoleAsync(Notification notification, int companyId, string role);

        public Task SendMembersEmailNotificationsAsync(Notification notification, List<BTUser> members);


    }
}