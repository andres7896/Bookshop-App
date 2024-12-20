using BookStoreApp.Context;
using BookStoreApp.DTOs;
using BookStoreApp.Entities;
using BookStoreApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApp.Services
{
    public class AuthorService: IAuthorService
    {

        private readonly DbConnection ctx;

        public AuthorService(DbConnection context)
        {
            ctx = context;
        }

        public List<AuthorsDto> GetAll()
        {
            try
            {
                return ctx.Authors
                          .Select(a => new AuthorsDto
                          {
                              Id_author = a.Id_author,
                              FullName = a.FullName,
                              CityOrigin = a.CityOrigin,
                              Email = a.Email,
                          })
                          .ToList();
            }
            catch
            {
                return null;
            }
        }

        public AuthorsDto GetByName(string name)
        {
            try
            {
                return ctx.Authors
                          .Select(a => new AuthorsDto
                          {
                              FullName = a.FullName,
                              CityOrigin = a.CityOrigin,
                              Email = a.Email,
                          })
                          .FirstOrDefault(a => a.FullName.ToLower() == name.ToLower());
            }
            catch
            {
                return null;
            }
        }

        public bool AddAuthor(Authors author)
        {
            try
            {
                ctx.Authors.Add(author);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAuthor(int id)
        {
            try
            {
                var author = ctx.Authors.FirstOrDefault(a => a.Id_author == id);
                if (author == null)
                    return false;
                ctx.Authors.Remove(author);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}