using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CohortHw_ModelUsing2.Common;
using CohortHw_ModelUsing2.Context;

namespace CohortHw_ModelUsing2.Operations.GetMovie;
public class GetMovieDetailQuery
{
    public int MovieId { get; set; }
    private readonly MovieDbContext _context;

    public GetMovieDetailQuery(MovieDbContext context){
        _context = context;
    }

    public List<GetMovieViewModel> Handle(){
        var movie = _context.Movies.Where(i => i.Id == MovieId).SingleOrDefault();
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

    public class GetMovieViewModel{
        public int Id { get; set; }
        public string? Name { get; set; }
        public double IMDB { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? PublishDate { get; set; }
    }
}
