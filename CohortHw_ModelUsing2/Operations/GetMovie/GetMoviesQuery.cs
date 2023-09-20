using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CohortHw_ModelUsing2.Common;
using CohortHw_ModelUsing2.Context;
using CohortHw_ModelUsing2.Entities;
using Microsoft.AspNetCore.Builder.Extensions;

namespace CohortHw_ModelUsing2.Operations.GetMovie;

public class GetMoviesQuery
{
    private readonly MovieDbContext _context;

    public GetMoviesQuery(MovieDbContext context){
        _context = context;
    }

    public List<GetMovieViewModel> Handle(){
        var movieList = _context.Movies.OrderBy(i => i.Id).ToList<Movie>();
        List<GetMovieViewModel> MovieViewList = new List<GetMovieViewModel>();
        foreach (var movie in movieList)
        {
            MovieViewList.Add(new GetMovieViewModel(){
                Id = movie.Id,
                Name = movie.Name,
                IMDB = movie.IMDB,
                Genre = ((GenreEnum)movie.GenreId).ToString(),
                Director = movie.Director,
                PublishDate = movie.PublishDate.Date.ToString("dd/MM/yyy")
            });
        }
        return MovieViewList;
    }

    public class GetMovieViewModel{
        public int Id { get; set; }
        public string? Name { get; set; }
        public double IMDB { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? PublishDate { get; set; }
    }

}
