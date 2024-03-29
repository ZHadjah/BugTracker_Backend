﻿using BugTracker_Backend.Data;
using BugTracker_Backend.Models.Enums;
using BugTracker_Backend.Services.Interfaces;
using BugTrackerBackend.Migrations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BugTracker_Backend.Services
{
    public class BTDashboardInfoService : IBTDashboardInfoService
    {
        private readonly ApplicationDbContext _context;

        public BTDashboardInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetDashboardNumbers()
        {
            Dictionary<string, int> dashboardNumbers = new();

            //Chart calculating Number of Tickets
            var numberOfTickets = await _context.Tickets.Select(s => s).CountAsync();
            dashboardNumbers.Add("NumberOfTickets", numberOfTickets);
            var numberOfProjects = await _context.Projects.Select(s => s).CountAsync();
            dashboardNumbers.Add("NumberOfProjects", numberOfProjects);
            var numberOfCompanies = await _context.Companies.Select(s => s).CountAsync();
            dashboardNumbers.Add("NumberofCompanies", numberOfCompanies);
            var numberOfUsers = await _context.Users.Select(s => s).CountAsync();
            dashboardNumbers.Add("NumberOfUsers", numberOfUsers);

            //Chart calculating Ticket Statuses
            var ticketsInNewStatus = await _context.Tickets.Where(s => s.TicketStatus.Name.Equals(BTTicketStatus.New.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInNewStatus", ticketsInNewStatus);
            var ticketsInDevelopmentStatus = await _context.Tickets.Where(s => s.TicketStatus.Name.Equals(BTTicketStatus.Development.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInDevelopmentStatus", ticketsInDevelopmentStatus);
            var ticketsInTestingStatus = await _context.Tickets.Where(s => s.TicketStatus.Name.Equals(BTTicketStatus.Testing.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInTestingStatus", ticketsInTestingStatus);
            var ticketsInResolvedStatus = await _context.Tickets.Where(s => s.TicketStatus.Name.Equals(BTTicketStatus.Resolved.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInResolvedStatus", ticketsInResolvedStatus);

            //Chart calculating Ticket Priorities
            var ticketsInUrgentPriority = await _context.Tickets.Where(s => s.TicketPriority.Name.Equals(BTTicketPriority.Urgent.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInUrgentPriority", ticketsInUrgentPriority);
            var ticketsInHighPriority = await _context.Tickets.Where(s => s.TicketPriority.Name.Equals(BTTicketPriority.High.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInHighPriority", ticketsInHighPriority);
            var ticketsInMediumPriority = await _context.Tickets.Where(s => s.TicketPriority.Name.Equals(BTTicketPriority.Medium.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInMediumPriority", ticketsInMediumPriority);
            var ticketsInLowPriority = await _context.Tickets.Where(s => s.TicketPriority.Name.Equals(BTTicketPriority.Low.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInLowPriority", ticketsInLowPriority);

            //Chart calculating Ticket Priorities
            var ticketsInNewDevType = await _context.Tickets.Where(s => s.TicketType.Name.Equals(BTTicketType.NewDevelopment.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInNewDevType", ticketsInNewDevType);
            var ticketsInWorkTaskType = await _context.Tickets.Where(s => s.TicketType.Name.Equals(BTTicketType.WorkTask.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInWorkTaskType", ticketsInWorkTaskType);
            var ticketsInDefectType = await _context.Tickets.Where(s => s.TicketType.Name.Equals(BTTicketType.Defect.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInDefectType", ticketsInDefectType);
            var ticketsInEnhancementType = await _context.Tickets.Where(s => s.TicketType.Name.Equals(BTTicketType.Enhancement.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInEnhancementType", ticketsInEnhancementType);
            var ticketsInChangeRequest = await _context.Tickets.Where(s => s.TicketType.Name.Equals(BTTicketType.ChangeRequest.ToString())).CountAsync();
            dashboardNumbers.Add("NumberOfTicketsInChangeRequestType", ticketsInChangeRequest);            
                
            string response =  JsonConvert.SerializeObject(dashboardNumbers, Formatting.Indented);
            return response;
        }
    }
}
