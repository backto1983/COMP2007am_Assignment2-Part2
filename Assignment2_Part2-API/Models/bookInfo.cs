using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Part2API.Models
{
    public class bookInfo
    {
        [Key]
        public int bookID { get; set; }
        [Required]
        public string bookName { get; set; }
        [Required]
        public string bookAuthor { get; set; }
        public string bookGenre { get; set; }
    }
}
