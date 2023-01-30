using BugTracker_Backend.Data;
using BugTracker_Backend.Models;
using BugTracker_Backend.Models.Enums;
using BugTracker_Backend.Services.Interfaces;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.Design;
using System.Data;

namespace BugTracker_Backend.Services
{
    public class BTNotificationService : IBTNotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IBTRolesService _rolesService;


        public BTNotificationService(ApplicationDbContext context,
                                    IEmailSender emailSender,
                                    IBTRolesService rolesService)
        {
            _context = context;
            _emailSender = emailSender;
            _rolesService = rolesService;
        }

        public async AddNotificationAsync(Notification notification)
        {
            try
            {
                await _context.AddAsync(notification);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async List<Notification> GetRecievedNotificationsAsync(string userId)
        {
            try
            {
                List<Notification> notifications = await _context.Notifications
                                                                 .Include(n=>n.Recipient)
                                                                 .Include(n=>n.Sender)
                                                                 .Include(n=>n.Ticket)
                                                                    .ThenInclude(t => t.project)
                                                                 .Where(n=> n.RecipientId == userId).ToListAsync();

                return notifications;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async List<Notification> GetSentNotificationAsync(string userId)
        {
            try
            {
                List<Notification> notifications = await _context.Notifications
                                                                 .Include(n=>n.Recipient)
                                                                 .Include(n=>n.Sender)
                                                                 .Include(n=>n.Ticket)
                                                                    .ThenInclude(t => t.project)
                                                                 .Where(n=> n.SenderId == userId).ToListAsync();

                return notifications;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SendEmailNotificationAsync(string userId)
        {
            BTUser btUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == notification.RecipientId);

            if(BTUser != null)
            {
                string btUserEmail = BTUser.Email;
                string message = notification.Message;

                //Send Email
                try
                {
                    await _emailSender.SendEmailAsync(btUserEmail, emailSubject, message);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else 
            {
                return false;
            }

        }

        public Task SendEmailNotificationsByRoleAsync(Notification notification, int companyId, string role)
        {
            try
            {
                List<BTUser> members = await _rolesService.GetUsersInRoleAsync(role, companyId);

                foreach(BTUser btUser in members)
                {
                    notification.RecipientId = btUser.Id;
                    await SendEmailNotificationAsync(notification, notification.Title);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async SendMembersEmailNotificationsAsync(Notification notification, List<BTUser> members)
        {
            try
            {
                foreach(BTUser btUser in members)
                {
                    notification.RecipientId = btUser.Id;
                    await SendEmailNotificationAsync(notification, notification.Title);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       

    }
}