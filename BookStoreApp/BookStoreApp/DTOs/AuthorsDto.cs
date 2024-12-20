using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApp.DTOs
{
    public class AuthorsDto
    {
        public int Id_author { get; set; }
        public string FullName { get; set; }
        public string CityOrigin { get; set; }
        public string Email { get; set; }
    }
}