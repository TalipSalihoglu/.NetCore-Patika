using System.Linq;
using System;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using Microsoft.Extensions.Configuration;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public CreateTokenModel Model;

        public CreateTokenCommand(BookStoreDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }
        public Token Handle()
        {
            var user=_context.Users.SingleOrDefault(x=>x.Email==Model.Email);
            if(user is not null)
            {
                TokenHandler handler=new TokenHandler(_config);
                Token token=handler.CreateAccessToken(user);  
                user.RefreshToken=token.RefreshToken;
                user.RefreshTokenExpireDate=token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("Kullanıcı adı - şifre hatalı");
                
        }
    }
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}