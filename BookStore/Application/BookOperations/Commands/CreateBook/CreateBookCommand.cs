﻿using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using BookStore.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BookStore.Application.BookOperations.Commands.CreateBook
{

    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut.");


            book = _mapper.Map<Book>(Model);

            // Artık AutoMapper Kullanıyoruz.

            //  book = new Book();
            //  book.Title = Model.Title;
            //  book.PublishDate = Model.PublishDate;
            //  book.PageCount = Model.PageCount;
            //  book.GenreId = Model.GenreId;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
