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
    [Route("api/bookInfo")]
    public class bookInfoController : Controller
    {
        private BookStoreModel db;

        public bookInfoController(BookStoreModel db)
        {
            this.db = db;
        }

        // GET: api/bookInfo
        [HttpGet]
        public IEnumerable<bookInfo> Get()
        {
            return db.bookInfo.OrderBy(a => a.bookName).ToList();
        }

        // GET: api/bookInfo/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var bookInfo = db.bookInfo.SingleOrDefault(a => a.bookID == id);

            if(bookInfo == null)
            {
                return NotFound();
            }

            return Ok(bookInfo);
        }
        
        // POST: api/bookInfo
        [HttpPost]
        public IActionResult Post([FromBody]bookInfo bookInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.bookInfo.Add(bookInfo);
            db.SaveChanges();
            return CreatedAtAction("Post", new { id = bookInfo.bookID }, bookInfo);
        }
        
        // PUT: api/bookInfo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]bookInfo bookInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Entry(bookInfo).State = EntityState.Modified;
            db.SaveChanges();
            return AcceptedAtAction("Get", new { id = bookInfo.bookID }, bookInfo);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookInfo = db.bookInfo.SingleOrDefault(a => a.bookID == id);

            if (bookInfo == null)
                return NotFound();

            db.bookInfo.Remove(bookInfo);
            db.SaveChanges();
            return Ok();
        }
    }
}
