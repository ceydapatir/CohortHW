using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_FluentValidation.Context;
using CohortHw_FluentValidation.Entities;
using CohortHw_FluentValidation.Models;

namespace CohortHw_FluentValidation.Operations.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }
        public CommandModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieDBContext _context;

        public UpdateMovieCommand(MovieDBContext context, IMapper mapper, int movieId, CommandModel model)
        {
            _context = context;
            _mapper = mapper;
            MovieId = movieId;
            Model = model;
        }

        // Data with MovieId is searched, if any it is replaced with a new one, otherwise it throws an error.
        public void Handle(){
            var movie = _context.Movies.Where(i => i.Id == MovieId).SingleOrDefault();
            if(movie is null)
                throw new InvalidOperationException("The movie doesn't exist.");
            else
                movie = _mapper.Map(Model,movie);  // Reverse movie with ViewModel
                _context.SaveChanges();
        }
    }
}