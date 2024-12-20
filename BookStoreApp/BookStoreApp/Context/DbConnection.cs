using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookStoreApp.Entities;

namespace BookStoreApp.Context
{
    public class DbConnection: DbContext
    {
        public DbConnection() : base("name=DbConnection")
        {
            Configuration.ProxyCreationEnabled = true;
        }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
    }
}