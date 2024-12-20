using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApp.Exceptions
{
    public class BookException: Exception
    {
        public BookException() { }

        public BookException(string message) : base(message) { }

    }
}