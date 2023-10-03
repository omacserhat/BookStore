using BookStore.DBOperations;
using BookStore.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                    new Book() { Title = "Book1", GenreId = 1, PageCount = 500, PublishDate = new System.DateTime(2005, 10, 23),AuthorId=1 },
                    new Book() { Title = "Book2", GenreId = 2, PageCount = 700, PublishDate = new System.DateTime(2013, 11, 22),AuthorId=2 },
                    new Book() { Title = "Book3", GenreId = 3, PageCount = 250, PublishDate = new System.DateTime(1998, 06, 17),AuthorId=3 }
                    );
        }
    }
}