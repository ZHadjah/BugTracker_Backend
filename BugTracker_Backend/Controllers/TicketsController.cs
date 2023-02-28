using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker_Backend.Data;
using BugTracker_Backend.Models;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace BugTracker_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets/NumberOfTickets
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> NumberOfTickets()
        {               
            var applicationDbContext = await _context.Tickets.Select(s => s).ToListAsync();
            int numberOfTickets = applicationDbContext.Count();

            return Ok(numberOfTickets);
        }


        // GET: Tickets
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = await _context.Tickets.Include(t => t.DeveloperUser).Include(t => t.OwnerUser).Include(t => t.Project).Include(t => t.TicketPriority).Include(t => t.TicketStatus).Include(t => t.TicketType).ToListAsync();
            ////return View(await applicationDbContext.ToListAsync());
            //return Ok(applicationDbContext);

            var applicationDbContext = await _context.Tickets.Select(s=>s).ToListAsync();

            var test = await _context.Tickets.Where(t => t.TicketPriorityId == 1).ToListAsync();
            //string testJsonString = JsonSerializer.Serialize(test);

            //string concat = $"{{\r\n  \"values\": [\r\n    {{\r\n      \"$id\": \"2\",\r\n      \"id\": 1,\r\n      \"projectId\": 1,\r\n      \"title\": \"Portfolio Ticket 1\",\r\n      \"description\": \"Ticket details for portfolio ticket 1\",\r\n      \"created\": \"2023-02-13T20:30:05.904904-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 1,\r\n      \"ticketTypeId\": 1,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"3\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"4\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"5\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"6\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"7\",\r\n      \"id\": 5,\r\n      \"projectId\": 1,\r\n      \"title\": \"Portfolio Ticket 5\",\r\n      \"description\": \"Ticket details for portfolio ticket 5\",\r\n      \"created\": \"2023-02-13T20:30:05.908844-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 1,\r\n      \"ticketTypeId\": 1,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"8\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"9\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"10\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"11\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"12\",\r\n      \"id\": 9,\r\n      \"projectId\": 2,\r\n      \"title\": \"Blog Ticket 1\",\r\n      \"description\": \"Ticket details for blog ticket 1\",\r\n      \"created\": \"2023-02-13T20:30:05.908845-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 1,\r\n      \"ticketTypeId\": 3,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"13\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"14\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"15\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"16\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"17\",\r\n      \"id\": 13,\r\n      \"projectId\": 2,\r\n      \"title\": \"Blog Ticket 5\",\r\n      \"description\": \"Ticket details for blog ticket 5\",\r\n      \"created\": \"2023-02-13T20:30:05.908846-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 2,\r\n      \"ticketTypeId\": 3,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"18\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"19\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"20\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"21\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"22\",\r\n      \"id\": 17,\r\n      \"projectId\": 2,\r\n      \"title\": \"Blog Ticket 9\",\r\n      \"description\": \"Ticket details for blog ticket 9\",\r\n      \"created\": \"2023-02-13T20:30:05.90885-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 1,\r\n      \"ticketTypeId\": 3,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"23\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"24\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"25\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"26\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"27\",\r\n      \"id\": 21,\r\n      \"projectId\": 2,\r\n      \"title\": \"Blog Ticket 13\",\r\n      \"description\": \"Ticket details for blog ticket 13\",\r\n      \"created\": \"2023-02-13T20:30:05.908852-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 1,\r\n      \"ticketTypeId\": 3,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"28\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"29\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"30\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"31\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"32\",\r\n      \"id\": 56,\r\n      \"projectId\": 5,\r\n      \"title\": \"Movie Ticket 1\",\r\n      \"description\": \"Ticket details for movie ticket 1\",\r\n      \"created\": \"2023-02-13T20:30:05.908865-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 1,\r\n      \"ticketTypeId\": 3,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"33\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"34\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"35\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"36\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"37\",\r\n      \"id\": 60,\r\n      \"projectId\": 5,\r\n      \"title\": \"Movie Ticket 5\",\r\n      \"description\": \"Ticket details for movie ticket 5\",\r\n      \"created\": \"2023-02-13T20:30:05.908866-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 2,\r\n      \"ticketTypeId\": 3,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"38\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"39\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"40\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"41\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"42\",\r\n      \"id\": 64,\r\n      \"projectId\": 5,\r\n      \"title\": \"Movie Ticket 9\",\r\n      \"description\": \"Ticket details for movie ticket 9\",\r\n      \"created\": \"2023-02-13T20:30:05.908867-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 1,\r\n      \"ticketTypeId\": 3,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"43\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"44\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"45\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"46\",\r\n        \"$values\": []\r\n      }}\r\n    }},\r\n    {{\r\n      \"$id\": \"47\",\r\n      \"id\": 68,\r\n      \"projectId\": 5,\r\n      \"title\": \"Movie Ticket 13\",\r\n      \"description\": \"Ticket details for movie ticket 13\",\r\n      \"created\": \"2023-02-13T20:30:05.90887-05:00\",\r\n      \"updated\": null,\r\n      \"archived\": false,\r\n      \"ticketPriorityId\": 1,\r\n      \"ticketStatusId\": 1,\r\n      \"ticketTypeId\": 3,\r\n      \"ownerUserId\": null,\r\n      \"developerUserId\": null,\r\n      \"project\": null,\r\n      \"ticketPriority\": null,\r\n      \"ticketStatus\": null,\r\n      \"ticketType\": null,\r\n      \"ownerUser\": null,\r\n      \"developerUser\": null,\r\n      \"comments\": {{\r\n        \"$id\": \"48\",\r\n        \"$values\": []\r\n      }},\r\n      \"attachments\": {{\r\n        \"$id\": \"49\",\r\n        \"$values\": []\r\n      }},\r\n      \"notifications\": {{\r\n        \"$id\": \"50\",\r\n        \"$values\": []\r\n      }},\r\n      \"history\": {{\r\n        \"$id\": \"51\",\r\n        \"$values\": []\r\n      }}\r\n    }}\r\n  ]\r\n}}";
            
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //string jsonString = JsonSerializer.Serialize(applicationDbContext);


            return Ok(applicationDbContext);
        }

        // GET: Tickets/Details/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return BadRequest(ModelState);
            }

            var ticket = await _context.Tickets
                .Include(t => t.DeveloperUser)
                .Include(t => t.OwnerUser)
                .Include(t => t.Project)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.TicketType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(ticket);
        }

        // GET: Tickets/Create
        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id");
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Id");
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Id");
            ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Id");
            return Ok();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,Title,Description,Created,Updated,Archived,TicketPriorityId,TicketStatusId,TicketTypeId,OwnerUserId,DeveloperUserId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return Ok(nameof(Index));
            }
            ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.DeveloperUserId);
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.OwnerUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", ticket.ProjectId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Id", ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Id", ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Id", ticket.TicketTypeId);
            return Ok(ticket);
        }

        // GET: Tickets/Edit/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return BadRequest(ModelState);
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return BadRequest(ModelState);
            }
            ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.DeveloperUserId);
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.OwnerUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", ticket.ProjectId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Id", ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Id", ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Id", ticket.TicketTypeId);
            return Ok(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,Title,Description,Created,Updated,Archived,TicketPriorityId,TicketStatusId,TicketTypeId,OwnerUserId,DeveloperUserId")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeveloperUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.DeveloperUserId);
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "Id", ticket.OwnerUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", ticket.ProjectId);
            ViewData["TicketPriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Id", ticket.TicketPriorityId);
            ViewData["TicketStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Id", ticket.TicketStatusId);
            ViewData["TicketTypeId"] = new SelectList(_context.TicketTypes, "Id", "Id", ticket.TicketTypeId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return BadRequest(ModelState);
            }

            var ticket = await _context.Tickets
                .Include(t => t.DeveloperUser)
                .Include(t => t.OwnerUser)
                .Include(t => t.Project)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.TicketType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tickets'  is null.");
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("[action]/{id}")]
        private bool TicketExists(int id)
        {
          return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
