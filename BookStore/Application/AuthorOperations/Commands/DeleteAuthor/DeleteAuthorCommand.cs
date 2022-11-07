using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            var book = _context.Books.SingleOrDefault(x => x.AuthorId == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Silinecek yazar bulunamadı.");
            }
            else if (book is not null)
            {
                throw new InvalidOperationException("Yazara ait kitap bulunmaktadır.");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
