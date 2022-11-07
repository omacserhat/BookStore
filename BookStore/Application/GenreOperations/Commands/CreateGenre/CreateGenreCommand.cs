using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;
using System;
using System.Linq;

namespace BookStore.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(obj => obj.Name.ToLower() == Model.Name.ToLower());
            if (genre is not null)
            {
                throw new InvalidOperationException("Kitap türü zaten kayıtlı.");
            }
            _context.Genres.Add(_mapper.Map<Genre>(Model));
            _context.SaveChanges();
        }

    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
