using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CohortHw_ModelUsing.Common;
using CohortHw_ModelUsing.Context;
using static CohortHw_ModelUsing.Operations.GetMovie.GetMoviesQuery;

namespace CohortHw_ModelUsing.Operations.GetMovie;
public class GetMovieDetailQuery
{
    private readonly MovieDbContext _context;

    public GetMovieDetailQuery(MovieDbContext context){
        _context = context;
    }

    public List<GetMovieViewModel> Handle(int id){
        var movie = _context.Movies.Where(i => i.Id == id).SingleOrDefault();
        List<GetMovieViewModel>  MovieViewList = new List<GetMovieViewModel>();
        if (movie is not null)
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
}
