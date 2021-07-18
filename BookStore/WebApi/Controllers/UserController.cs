using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Application.UserOperations.Commands.CreateToken;
using WebApi.Application.UserOperations.Commands.CreateUser;
using WebApi.Application.UserOperations.Commands.RefreshToken;
using WebApi.DbOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _config;
        public UserController(BookStoreDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command=new CreateUserCommand(_context,_mapper);
            command.Model=newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command=new CreateTokenCommand(_context,_mapper,_config);
            command.Model=login;
            var token =command.Handle();

            return Ok(token);
        }
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command=new RefreshTokenCommand(_context,_config);
            command.refreshToken=token;
            var resulttoken =command.Handle();

            return resulttoken; 
        }
    }
}