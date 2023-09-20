using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CohortHw_ModelUsing2.Context;
using CohortHw_ModelUsing2.Entities;

namespace CohortHw_ModelUsing2.Operations.UpdateMovie;

public class UpdateMovieCommand
{
    public int MovieId { get; set; }
    public UpdateMovieViewModel UpdateModel { get; set; }
    private readonly MovieDbContext _context;

    public UpdateMovieCommand(MovieDbContext context){
        _context = context;
    }

    public void Handle(){
        var movie = _context.Movies.Where(i => i.Id == MovieId).SingleOrDefault();
        if (movie is null)
            throw new InvalidOperationException("The movie already exists.");
        
        movie.Name = UpdateModel.Name != movie.Name ? UpdateModel.Name : movie.Name;
        movie.IMDB = UpdateModel.IMDB != movie.IMDB ? UpdateModel.IMDB : movie.IMDB;
        movie.Director = UpdateModel.Director != movie.Director ? UpdateModel.Director : movie.Director;
        movie.PublishDate = UpdateModel.PublishDate != movie.PublishDate ? UpdateModel.PublishDate : movie.PublishDate;
        movie.BannerUrl = UpdateModel.BannerUrl != movie.BannerUrl ? UpdateModel.BannerUrl : movie.BannerUrl;
        movie.GenreId = UpdateModel.GenreId != movie.GenreId ? UpdateModel.GenreId : movie.GenreId;
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
