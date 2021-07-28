using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.MovieOperations.Commands.CreateMovie;
using Webapi.Application.MovieOperations.Commands.DeleteMovie;
using Webapi.Application.MovieOperations.Commands.UpdateMovie;
using Webapi.Application.MovieOperations.Queries.GetMovieDetai;
using Webapi.DbOperations;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies(){
            GetMoviesQuery query=new GetMoviesQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetMovies(int id){
            GetMovieDetailQuery query=new GetMovieDetailQuery(_context,_mapper);
            query.MovieId=id;

            GetMovieDetailQueryValidator validations=new GetMovieDetailQueryValidator();
            validations.ValidateAndThrow(query);

            var result=query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie){
            CreateMovieCommand command=new CreateMovieCommand(_context,_mapper);
            command.Model=newMovie;

            CreateMovieCommandValidator validations=new CreateMovieCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id,[FromBody] UpdateMovieModel updateMovie){
            UpdateMovieCommand command= new UpdateMovieCommand(_context);
            command.MovieId=id;
            command.Model=updateMovie;

            UpdateMovieCommandValidator validations=new UpdateMovieCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
         }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command=new DeleteMovieCommand(_context);
            command.MovieId=id;

            DeleteMovieCommandValidator validations=new DeleteMovieCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}