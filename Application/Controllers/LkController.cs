using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IActionResult Get()
        {
            var result = from user in _context.Users
                        select new
                        {
                            user.FirstName,
                            user.MiddleName,
                            user.LastName,
                            user.Age
                        };
            return new OkObjectResult(result);
        }

        //GET: api/Lk/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = _context.Users.ElementAt(id);

            return new OkObjectResult(result);
        }

        // PUT: api/Lk/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserShort value)
        {
           var user = _context.Users.ToArray()[id];
            user.FirstName = value.FirstName;
            user.MiddleName = value.MiddleName;
            user.LastName = value.LastName;
            user.Age = value.Age;
            _context.SaveChanges();
        }
    }
}
