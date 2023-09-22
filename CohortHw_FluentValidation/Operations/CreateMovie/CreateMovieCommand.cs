using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_FluentValidation.Context;
using CohortHw_FluentValidation.Entities;
using CohortHw_FluentValidation.Models;

namespace CohortHw_FluentValidation.Operations.CreateMovie
{
    public class CreateMovieCommand
    {
        public CommandModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieDBContext _context;

        public CreateMovieCommand(MovieDBContext context, IMapper mapper, CommandModel model){
            _context = context;
            _mapper = mapper;
            Model = model;
        }

        // If there is no other movie with the same name, it will be added and if there is, it will throw an error.
        public void Handle(){
            var movie = _context.Movies.Where(i => i.Name == Model.Name).SingleOrDefault();
            if(movie is not null)
                throw new InvalidOperationException("The movie already exists.");
            else
                movie = _mapper.Map<Movie>(Model);  // Convert ViewModel from CommandViewModel to Movie type
                _context.Movies.Add(movie);
                _context.SaveChanges();
        }
    }
}