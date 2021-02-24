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
    [Route("/users")]
    public class UserController : ControllerBase
    {

        private readonly ApiDatabaseContext _context;

        public UserController(ApiDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{username}")]
        public object Get(string username)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), user);
        }
    }
}
