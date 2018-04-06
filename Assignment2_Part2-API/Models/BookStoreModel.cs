using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Part2API.Models
{
    [Table("bookInfo")]
    public class BookStoreModel : DbContext
    {
        // Constructor
        public BookStoreModel(DbContextOptions<BookStoreModel>options) : base(options)
        {

        }

        public DbSet<bookInfo> bookInfo { get; set; }
    }
}
