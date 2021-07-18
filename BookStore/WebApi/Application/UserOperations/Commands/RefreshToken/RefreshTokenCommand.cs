using System.Linq;
using System;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using Microsoft.Extensions.Configuration;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IConfiguration _config;
        public string refreshToken{get;set;}

        public RefreshTokenCommand(BookStoreDbContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public Token Handle()
        {
            var user=_context.Users.SingleOrDefault(x=>x.RefreshToken==refreshToken && x.RefreshTokenExpireDate>DateTime.Now);
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
                throw new InvalidOperationException("Geçerli refresh token bulunamadı");
                
        }
    }
}