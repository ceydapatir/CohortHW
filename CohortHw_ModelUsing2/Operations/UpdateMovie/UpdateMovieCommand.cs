using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_ModelUsing2.Context;
using CohortHw_ModelUsing2.Entities;

namespace CohortHw_ModelUsing2.Operations.UpdateMovie;

public class UpdateMovieCommand
{
    public int MovieId { get; set; }
    public UpdateMovieViewModel UpdateModel { get; set; }
    private readonly MovieDbContext _context;
    private readonly IMapper _mapper;

    public UpdateMovieCommand(MovieDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    public void Handle(){
        var movie = _context.Movies.Where(i => i.Id == MovieId).SingleOrDefault();
        if (movie is null)
            throw new InvalidOperationException("The movie doesn't exist.");
        
        movie = _mapper.Map<Movie>(UpdateModel);
        _context.SaveChanges();
    }

    public class UpdateMovieViewModel{
        public string? Name { get; set; }
        public double IMDB { get; set; }
        public int GenreId { get; set; }
        public string? Director { get; set; }
        public DateTime PublishDate { get; set; }
        public string? BannerUrl { get; set; }
    }
}
