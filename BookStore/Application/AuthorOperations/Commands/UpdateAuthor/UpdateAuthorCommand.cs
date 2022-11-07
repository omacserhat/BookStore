using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı.");
            }
            author.FirstName = Model.FirstName == default ? author.FirstName : Model.FirstName;
            author.LastName = Model.LastName == default ? author.LastName : Model.LastName;
            author.Birthday = Model.Birthday == default ? author.Birthday : Model.Birthday;
            _context.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
