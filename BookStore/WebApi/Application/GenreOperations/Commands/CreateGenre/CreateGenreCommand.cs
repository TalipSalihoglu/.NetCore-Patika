using System.Linq;
using System;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model{get;set;}
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre= _context.Genres.SingleOrDefault(x=>x.Name==Model.Name);
            if(genre is not null)
                throw new InvalidOperationException("Kitap türü zaten kayıtlı.");

            genre =new Genre();
            genre.Name=Model.Name;
            
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}