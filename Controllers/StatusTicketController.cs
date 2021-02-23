using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using double_v_partners.Models;
using Microsoft.Extensions.Logging;
using double_v_partners.Data;

namespace double_v_partners.Controllers
{
    [ApiController]
    [Route("/status_tickets")]
    public class StatusTicketController : ControllerBase
    {

        private readonly ApiDatabaseContext _context;

        public StatusTicketController(ApiDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get()
        {
            return _context.StatusTickets.ToList();
        }
    }
}
