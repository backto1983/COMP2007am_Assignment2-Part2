using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Part2API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Part2_API.Controllers
{
    [Produces("application/json")]
    [Route("api/bookLocations")]
    public class bookLocationsController : Controller
    {
        private BookStoreModel db;

        public bookLocationsController(BookStoreModel db)
        {
            this.db = db;
        }

        // GET: api/bookLocations
        [HttpGet]
        public IEnumerable<bookLocation> Get()
        {
            return db.bookLocations.OrderBy(a => a.bookStoreLocation).ToList();
        }

        // GET: api/bookLocations/5
        [HttpGet("{id}", Name = "GetLocation")]  // Changed "Name' to avoid an error when routes for bookInfo
                                                 // bookLocations have the same name
        public IActionResult Get(int id)
        {
            var bookLocation = db.bookLocations.SingleOrDefault(a => a.bookStoreNumber == id);

            if (bookLocation == null)
            {
                return NotFound();
            }

            return Ok(bookLocation);
        }
        
        // POST: api/bookLocations
        [HttpPost]
        public IActionResult Post([FromBody]bookLocation bookLocation)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.bookLocations.Add(bookLocation);
            db.SaveChanges();
            return CreatedAtAction("Post", new { id = bookLocation.bookID }, bookLocation);
        }
        
        // PUT: api/bookLocations/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]bookLocation bookLocation)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            db.Entry(bookLocation).State = EntityState.Modified;
            db.SaveChanges();
            return AcceptedAtAction("Get", new { id = bookLocation.bookID }, bookLocation);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookLocation = db.bookLocations.SingleOrDefault(a => a.bookID == id);

            if (bookLocation == null)
                return NotFound();

            db.bookLocations.Remove(bookLocation);
            db.SaveChanges();
            return Ok();
        }
    }
}
