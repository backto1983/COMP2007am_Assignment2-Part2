using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Part2API.Models
{
    public class bookLocation
    {
        [Key]
        public int bookStoreNumber { get; set; }
        public int bookID { get; set; }
        [Required]
        public string bookStoreLocation { get; set; }
        [Required]
        public string bookShelve { get; set; }
        public string bookPhysical { get; set; }
    }
}
