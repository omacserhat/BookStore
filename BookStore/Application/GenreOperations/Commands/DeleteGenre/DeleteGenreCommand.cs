using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly IBookStoreDbContext _context;
        public DeleteGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Silinecek kitap türü bulunamadı.");
            }
            genre.IsActive = false;
            //_context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
