using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CohortHw_ModelUsing2.Context;

namespace CohortHw_ModelUsing2.Operations.DeleteMovie;

public class DeleteMovieCommand
{
    public int MovieId { get; set; }
    private readonly MovieDbContext _context;

    public DeleteMovieCommand(MovieDbContext context){
        _context = context;
    }

    public void Handle(){
        var movie = _context.Movies.Where(i => i.Id == MovieId).SingleOrDefault();
        if (movie is null)
            throw new InvalidOperationException("The movie already exists.");
        
        _context.Movies.Remove(movie);
        _context.SaveChanges();
    }
}
