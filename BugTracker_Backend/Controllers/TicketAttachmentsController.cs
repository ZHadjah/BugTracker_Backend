﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker_Backend.Data;
using BugTracker_Backend.Models;

namespace BugTracker_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketAttachmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketAttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TicketAttachments
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TicketAttachments.Include(t => t.Ticket).Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TicketAttachments/Details/5
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TicketAttachments == null)
            {
                return BadRequest(ModelState);
            }

            var ticketAttachment = await _context.TicketAttachments
                .Include(t => t.Ticket)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketAttachment == null)
            {
                return BadRequest(ModelState);
            }

            return View(ticketAttachment);
        }

        // GET: TicketAttachments/Create
        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TicketAttachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Create([Bind("Id,TicketId,Created,UserId,Description,FileName,FileData,FileContentType")] TicketAttachment ticketAttachment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketAttachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", ticketAttachment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticketAttachment.UserId);
            return View(ticketAttachment);
        }

        // GET: TicketAttachments/Edit/5
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TicketAttachments == null)
            {
                return BadRequest(ModelState);
            }

            var ticketAttachment = await _context.TicketAttachments.FindAsync(id);
            if (ticketAttachment == null)
            {
                return BadRequest(ModelState);
            }
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", ticketAttachment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticketAttachment.UserId);
            return View(ticketAttachment);
        }

        // POST: TicketAttachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketId,Created,UserId,Description,FileName,FileData,FileContentType")] TicketAttachment ticketAttachment)
        {
            if (id != ticketAttachment.Id)
            {
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketAttachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketAttachmentExists(ticketAttachment.Id))
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
            ViewData["TicketId"] = new SelectList(_context.Tickets, "Id", "Id", ticketAttachment.TicketId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ticketAttachment.UserId);
            return View(ticketAttachment);
        }

        // GET: TicketAttachments/Delete/5
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TicketAttachments == null)
            {
                return BadRequest(ModelState);
            }

            var ticketAttachment = await _context.TicketAttachments
                .Include(t => t.Ticket)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketAttachment == null)
            {
                return BadRequest(ModelState);
            }

            return View(ticketAttachment);
        }

        // POST: TicketAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TicketAttachments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TicketAttachments'  is null.");
            }
            var ticketAttachment = await _context.TicketAttachments.FindAsync(id);
            if (ticketAttachment != null)
            {
                _context.TicketAttachments.Remove(ticketAttachment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("[action]")]
        private bool TicketAttachmentExists(int id)
        {
          return (_context.TicketAttachments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
