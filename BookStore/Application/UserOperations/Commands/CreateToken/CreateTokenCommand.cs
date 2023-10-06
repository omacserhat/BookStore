using AutoMapper;
using BookStore.DBOperations;
using BookStore.TokenOperations;
using BookStore.TokenOperations.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace BookStore.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IBookStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x=>x.Email == Model.Email && x.Password == Model.Password);
            if(user is not null)
            {
                //Token yarat
                TokenHandler handler = new TokenHandler(_configuration);

                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;

                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(3);

                _dbContext.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı adı veya şifre hatalı");
            }
        }

        public class CreateTokenModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
