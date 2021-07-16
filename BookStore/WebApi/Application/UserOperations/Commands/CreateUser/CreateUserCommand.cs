using System.Linq;
using System;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserModel Model;

        public CreateUserCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user=_context.Users.SingleOrDefault(x=>x.Email==Model.Email); 
            if(user is not null)
                throw new InvalidOperationException("Bu kullanıcı mail adresi zaten kayıtlı");
            
            user = _mapper.Map<User>(Model);
            _context.Users.Add(user);
            _context.SaveChanges();

        }

    }
    public class CreateUserModel
    {
          public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password {get;set;}
    }
}