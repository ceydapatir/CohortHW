using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CohortHw_ModelUsing.Context;
using Microsoft.AspNetCore.Mvc;

namespace CohortHw_ModelUsing.Operations.CreateMovie;

public class CreateMovieCommand
{
    public CreateMovieViewModel CreateModel { get; set; }
    private readonly MovieDbContext _context;

    public CreateMovieCommand(MovieDbContext context){
        _context = context;
    }

    public void Handle(CreateMovieViewModel moviemodel){
        var movie = _context.Movies.Where(i => i.Name == moviemodel.Name).SingleOrDefault();
            if(movie is not null){
                throw new InvalidOperationException("The movie already exists.");
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();
    }

    public class CreateMovieViewModel{
        public string? Name { get; set; }
        public double IMDB { get; set; }
        public int GenreId { get; set; }
        public string? Director { get; set; }
        public DateTime PublishDate { get; set; }
    }
}