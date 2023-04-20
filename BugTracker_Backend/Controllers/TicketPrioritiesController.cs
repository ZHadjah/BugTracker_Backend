using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker_Backend.Data;
using BugTracker_Backend.Models;
using BugTracker_Backend.Services.Interfaces;

namespace BugTracker_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketPrioritiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBTDropDownOptionsService _dropDownOptionsService;

        public TicketPrioritiesController(ApplicationDbContext context,
                                          IBTDropDownOptionsService dropDownOptionsService)
        {
            _context = context;
            _dropDownOptionsService = dropDownOptionsService;
        }

        // GET: TicketPriorities
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
              return _context.TicketPriorities != null ? 
                          View(await _context.TicketPriorities.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TicketPriorities'  is null.");
        }

        // GET: TicketPriorities/Details/5
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TicketPriorities == null)
            {
                return BadRequest(ModelState);
            }

            var ticketPriority = await _context.TicketPriorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketPriority == null)
            {
                return BadRequest(ModelState);
            }

            return View(ticketPriority);
        }

        // GET: TicketPriorities/Create
        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketPriorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Create([Bind("Id,Name")] TicketPriority ticketPriority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketPriority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketPriority);
        }

        // GET: TicketPriorities/Edit/5
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TicketPriorities == null)
            {
                return BadRequest(ModelState);
            }

            var ticketPriority = await _context.TicketPriorities.FindAsync(id);
            if (ticketPriority == null)
            {
                return BadRequest(ModelState);
            }
            return View(ticketPriority);
        }

        // POST: TicketPriorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TicketPriority ticketPriority)
        {
            if (id != ticketPriority.Id)
            {
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketPriority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketPriorityExists(ticketPriority.Id))
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
            return View(ticketPriority);
        }

        // GET: TicketPriorities/Delete/5
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TicketPriorities == null)
            {
                return BadRequest(ModelState);
            }

            var ticketPriority = await _context.TicketPriorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketPriority == null)
            {
                return BadRequest(ModelState);
            }

            return View(ticketPriority);
        }

        // POST: TicketPriorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TicketPriorities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TicketPriorities'  is null.");
            }
            var ticketPriority = await _context.TicketPriorities.FindAsync(id);
            if (ticketPriority != null)
            {
                _context.TicketPriorities.Remove(ticketPriority);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("[action]")]
        private bool TicketPriorityExists(int id)
        {
          return (_context.TicketPriorities?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: TicketPriorities/Options
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Options()
        {
            var dropDownInfo = _dropDownOptionsService.GetAllTicketPrioritiesAsync();

            return Ok(dropDownInfo);

        }
    }
}
