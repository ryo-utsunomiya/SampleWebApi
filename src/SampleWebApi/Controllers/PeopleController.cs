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

        // POST api/People
        [HttpPost]
        public async Task<int> Post([FromBody]Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }

        // PUT api/People/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody]Person person)
        {
            if (id != person.Id)
            {
                return -1;
            }

            _context.Update(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }

        // DELETE api/People/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var person = await _context.Person.SingleOrDefaultAsync(m => m.Id == id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
