using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LkController : ControllerBase
    {
        private ApplicationContext _context;

        public LkController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Lk
        [HttpGet]
        public IEnumerable<UserShort> Get()
        {
            var users = new List<UserShort>();

            for (int i = 0; i < _context.Users.Count(); i++) {

                users.Add(new UserShort {
                    FirstName = _context.Users.ToArray()[i].FirstName,
                    MiddleName = _context.Users.ToArray()[i].MiddleName,
                    LastName = _context.Users.ToArray()[i].LastName,
                    Age = _context.Users.ToArray()[i].Age
                });
            }

            return users.ToArray();
        }

        //GET: api/Lk/5
        [HttpGet("{id}", Name = "Get")]
        public UserShort Get(int id)
        {
            return new UserShort
            {
                FirstName = _context.Users.ToArray()[id].FirstName,
                MiddleName = _context.Users.ToArray()[id].MiddleName,
                LastName = _context.Users.ToArray()[id].LastName,
                Age = _context.Users.ToArray()[id].Age
            };
        }

        // POST: api/Lk
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/Lk/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserShort value)
        {
            _context.Users.ToArray()[id].FirstName = value.FirstName;
            _context.Users.ToArray()[id].MiddleName = value.FirstName;
            _context.Users.ToArray()[id].LastName = value.LastName;
            _context.Users.ToArray()[id].Age = value.Age;
            _context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
