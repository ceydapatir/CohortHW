using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_ModelUsing2.Context;
using CohortHw_ModelUsing2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CohortHw_ModelUsing2.Operations.CreateMovie;

public class CreateMovieCommand
{
    public CreateMovieViewModel CreateModel { get; set; }
    private readonly MovieDbContext _context;
    private readonly IMapper _mapper;
    public CreateMovieCommand(MovieDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    public void Handle(){
        var movie = _context.Movies.Where(i => i.Name == CreateModel.Name).SingleOrDefault();
        if(movie is not null){
            throw new InvalidOperationException("The movie already exists.");
        }

        movie = _mapper.Map<Movie>(CreateModel);
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public class CreateMovieViewModel{
        public string? Name { get; set; }
        public double IMDB { get; set; }
        public int GenreId { get; set; }
        public string? Director { get; set; }
        public DateTime PublishDate { get; set; }
        public string? BannerUrl { get; set; }
    }
}