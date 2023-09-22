using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CohortHw_FluentValidation.Context;

namespace CohortHw_FluentValidation.Operations.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly MovieDBContext _context;

        public DeleteMovieCommand(MovieDBContext context, int movieId){
            _context = context;
            MovieId = movieId;
        }

        // Data with MovieId is searched, if any it is deleted, otherwise it throws an error.
        public void Handle(){
            var movie = _context.Movies.Where(i => i.Id == MovieId).SingleOrDefault();
            if(movie is null)
                throw new InvalidOperationException("The movie doesn't exist.");
            else
                _context.Movies.Remove(movie);
                _context.SaveChanges();
        }
    }
}