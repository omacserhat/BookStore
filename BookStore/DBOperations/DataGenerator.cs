﻿using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any() && context.Genres.Any() && context.Authors.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 0, // Personal Growth
                        PageCount = 200,
                        PublishDate = new System.DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 1, // Science Fiction
                        PageCount = 250,
                        PublishDate = new System.DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 1, // Science Fiction
                        PageCount = 540,
                        PublishDate = new System.DateTime(2001, 12, 21)
                    }
                );
                context.Genres.AddRange(
                    new Genre()
                    {
                        Name = "Personal Growth"
                    },
                    new Genre()
                    {
                        Name = "Science Fiction"
                    },
                    new Genre()
                    {
                        Name = "Noval"
                    }
                );
                context.Authors.AddRange(
                    new Author()
                    {
                        FirstName = "AuthorFN1",
                        LastName = "AuthorLN1",
                        Birthday = new DateTime(1990, 10, 05)
                    },
                    new Author()
                    {
                        FirstName = "AuthorFN2",
                        LastName = "AuthorLN2",
                        Birthday = new DateTime(2000, 06, 18)
                    },
                    new Author()
                    {
                        FirstName = "AuthorFN3",
                        LastName = "AuthorLN3",
                        Birthday = new DateTime(1985, 04, 23)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
