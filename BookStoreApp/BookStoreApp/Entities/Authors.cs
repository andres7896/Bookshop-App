using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStoreApp.Entities
{
    public class Authors
    {
        [Key]
        public int Id_author { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(30)]
        public string CityOrigin { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}