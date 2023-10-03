using BookStore.DBOperations;
using BookStore.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                    new Author() { FirstName = "AuthorFN1", LastName = "AuthorLN1", Birthday = new DateTime(1990, 10, 05) },
                    new Author() { FirstName = "AuthorFN2", LastName = "AuthorLN2", Birthday = new DateTime(2000, 06, 18) },
                    new Author() { FirstName = "AuthorFN3", LastName = "AuthorLN3", Birthday = new DateTime(1985, 04, 23) }
                    );
        }
    }
}