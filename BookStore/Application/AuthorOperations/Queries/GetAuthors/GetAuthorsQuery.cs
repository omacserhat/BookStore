using AutoMapper;
using BookStore.DBOperations;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var authors = _context.Authors.ToList();
            var lst = _mapper.Map<List<AuthorViewModel>>(authors);
            return lst;
        }
    }
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
    }
}
