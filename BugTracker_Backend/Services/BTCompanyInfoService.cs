using BugTracker_Backend.Data;
using BugTracker_Backend.Models;
using BugTracker_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BugTracker_Backend.Services
{
    public class BTCompanyInfoService : IBTCompanyInfoService
    {
        private readonly ApplicationDbContext _context;

        public BTCompanyInfoService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<BTUser>> GetAllMembersAsync(int companyId)
        {
            List<BTUser> members = await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();
            return members;
        }

        //Get all the projects using the company ID as a parameter input
        public async Task<List<Project>> GetAllProjectsAsync(int companyId)
        {
            List<Project> projects = await _context.Projects.Where(u => u.CompanyId == companyId)
                                                            .Include(p => p.Members)
                                                            .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.Comments)
                                                            .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.Attachments)
                                                            .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.History)
                                                            .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.Notifications)
                                                            .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.DeveloperUser)
                                                            .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.OwnerUser)
                                                            .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.TicketStatus)
                                                             .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.TicketPriority)
                                                             .Include(p => p.Tickets)
                                                                .ThenInclude(t => t.TicketType)
                                                             .Include(p => p.ProjectPriority)
                                                            .ToListAsync();
            return projects;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync(int companyId)
        {
            
            List<Project> projects = await GetAllProjectsAsync(companyId);
            List<Ticket> result = projects.SelectMany(p => p.Tickets).ToList();
                      
            return result;
        }

        public async Task<Company> GetCompanyInfoByIdAsync(int? companyId)
        {
            Company result = new();
                
            if(companyId != null)
            {
                result = await _context.Companies
                    .Include(c => c.Members)
                    .Include(c => c.Projects)
                    .Include(c => c.Invites)
                    
                    
                    
                    .FirstOrDefaultAsync(c => c.Id == companyId);
            }

            return result;
        }
    }
}
