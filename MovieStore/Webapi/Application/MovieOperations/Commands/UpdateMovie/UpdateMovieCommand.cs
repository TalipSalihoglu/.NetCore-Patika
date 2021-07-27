using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;
using System;
using Webapi.Entities;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie{
    public class UpdateMovieCommand{
        private readonly MovieStoreDbContext _context;
        public UpdateMovieModel Model{get;set;}
        public int MovieId{get;set;}
        public UpdateMovieCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var movie=_context.Movies.SingleOrDefault(x=>x.Id==MovieId);
            if(movie==null)
                throw new InvalidOperationException("Kayıt bulunamadı.");
            
            movie.GenreId=Model.GenreId!=default ? Model.GenreId:movie.GenreId;
            movie.DirectorId=Model.DirectorId!=default ? Model.DirectorId:movie.DirectorId;
            movie.Name=Model.Name!=default ? Model.Name:movie.Name;
            movie.Price=Model.Price!=default ? Model.Price:movie.Price;
            _context.SaveChanges();
        }
    }
    public class UpdateMovieModel{
        public string Name{get;set;}
        public int GenreId{get;set;}
        public int DirectorId{get;set;}
        public decimal Price{get;set;}
    }
}