using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApp.Models
{
    public class BooksThatBought
    {
        [Key]
        public int PurchaseId { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book book { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public BookUser bookUser { get; set; }
    }
}
