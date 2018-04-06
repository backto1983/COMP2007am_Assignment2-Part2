using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Part2API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/bookInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
