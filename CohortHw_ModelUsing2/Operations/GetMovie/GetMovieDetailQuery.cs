using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_ModelUsing2.Common;
using CohortHw_ModelUsing2.Context;
using CohortHw_ModelUsing2.Entities;

namespace CohortHw_ModelUsing2.Operations.GetMovie;
public class GetMovieDetailQuery
{
    public int MovieId { get; set; }
    private readonly MovieDbContext _context;
    private readonly IMapper _mapper;

    public GetMovieDetailQuery(MovieDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    public GetMovieDetailViewModel Handle(){
        var movie = _context.Movies.Where(i => i.Id == MovieId).SingleOrDefault();
        if (movie is null)
            throw new InvalidOperationException("The movie doesn't exist.");
            
        GetMovieDetailViewModel vm = _mapper.Map<GetMovieDetailViewModel>(movie);
        return vm;
    }

    public class GetMovieDetailViewModel{
        public string? Name { get; set; }
        public double IMDB { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? PublishDate { get; set; }
    }
}
