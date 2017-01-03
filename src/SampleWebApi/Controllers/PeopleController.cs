using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApi.Data;
using SampleWebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
            Prefecture.Initialize(_context);
        }

        // GET: api/People
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.Person.Include(p => p.Prefegture).ToListAsync();
        }

        // GET api/People/5
        [HttpGet("{id}")]
        public async Task<Person>  Get(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Person
                .Include(p => p.Prefegture)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
