using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApp.Models
{
    public class BookUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        public float Wallet { get; set; }

        [Required]
        public string Role { get; set; }

        public List<BooksThatBought> booksThatBoughts { get; set; }
    }
}
