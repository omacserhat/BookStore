using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.GenreOperations.Commands.CreateGenre;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.Application.GenreOperations.Queries.GetGenres;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using BookStore.Entities;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;

namespace BookStore.Common
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//Book
			CreateMap<CreateBookModel, Book>();
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
			//Author
            CreateMap<Author, AuthorViewModel>().ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.Date.ToString("dd/MM/yyyy")));
            CreateMap<Author, AuthorDetailViewModel>().ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.Date.ToString("dd/MM/yyyy")));
            CreateMap<CreateAuthorModel, Author>();
            //Genre
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();
        }
	}
}