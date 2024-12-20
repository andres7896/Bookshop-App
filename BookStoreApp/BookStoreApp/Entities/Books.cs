using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BookStoreApp.Entities
{
    public class Books
    {
        [Key]
        public int Id_book { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [IntegerValidator]
        public int Year { get; set; }
        public string Gender { get; set; }
        public int PagesNumber { get; set; }
        [Required]
        [IntegerValidator]
        [ForeignKey("Author")]
        public int Id_author { get; set; }
        public virtual Authors Author { get; set; }
        [NotMapped]
        public string AuthorQuery { get; set; }
    }
}