using BookStoreApp.DTOs;
using BookStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorsDto> GetAll();
        AuthorsDto GetByName(string name);
        bool AddAuthor(Authors author);
        bool DeleteAuthor(int id);        
    }
}
