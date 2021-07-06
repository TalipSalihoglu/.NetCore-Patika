using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;
using AutoMapper;
using FluentValidation;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController (BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query =new GetGenresQuery(_context,_mapper);
            var genres=query.Handle();
            return Ok(genres);
        }

        [HttpGet("id")]
        public IActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query=new GetGenreDetailQuery(_context,_mapper);
            query.GenreId=id;
            GetGenreDetailQueryValidator validator=new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var genres=query.Handle();
            return Ok(genres);
        }    

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command=new CreateGenreCommand(_context,_mapper);
            command.Model=newGenre;
            CreateGenreCommandValidator validator=new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel newGenre)
        {
            UpdateGenreCommand command =new UpdateGenreCommand(_context);
            command.GenreId=id;
            command.Model=newGenre;
            UpdateGenreCommandValidator validator=new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command=new DeleteGenreCommand(_context);
            command.GenreId=id;
            DeleteGenreCommandValidator validator=new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        
    }
}    