using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using double_v_partners.Models;
using Microsoft.Extensions.Logging;
using double_v_partners.Data;
using Microsoft.EntityFrameworkCore;

namespace double_v_partners.Controllers
{
    [ApiController]
    [Route("/tickets")]
    public class TicketController : ControllerBase
    {

        private readonly ApiDatabaseContext _context;

        public TicketController(ApiDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get()
        {
            return _context.Tickets.ToList();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(ticket => ticket.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> Post(Ticket ticket)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == ticket.UserId);
            var status = _context.StatusTickets.FirstOrDefault(status => status.Id == ticket.StatusId);

            if (user == null || status == null)
            {
                return BadRequest("El usuario o estado no existe");
            }

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), ticket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(ticket => ticket.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ticket>> Put(int id, Ticket data)
        {
            var ticket = _context.Tickets.SingleOrDefault(ticket => ticket.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket.UserId = data.UserId;
            ticket.StatusId = data.StatusId;

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            return Ok(ticket);
        }
    }
}
