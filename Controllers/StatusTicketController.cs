using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using double_v_partners.Models;
using Microsoft.Extensions.Logging;

namespace double_v_partners.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusTicketController : ControllerBase
    {
        
        [ht]
        public IEnumerable<StatusTicket> Get()
        {

        }
    
    }
}
