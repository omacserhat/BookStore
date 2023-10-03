using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using BookStore.Application.BookOperations.Commands.CreateBook;
using BookStore.DBOperations;
using BookStore.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidExceptionOperation_ShouldBeReturn()
        {
            //Arrange(Hazırlık)
            var book = new Book(){Title  = "WhenAlreadyExistBookTitleIsGiven_InvalidExceptionOperation_ShouldBeReturn", GenreId=1, PageCount=100, PublishDate=new System.DateTime(1990,10,23)};
            _context.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = new CreateBookModel(){Title=book.Title};

            //Act(Çalıştırma) & Assert(Doğrulama)
            FluentActions
                .Invoking(()=>command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Kitap zaten mevcut.");
        }

    }

}