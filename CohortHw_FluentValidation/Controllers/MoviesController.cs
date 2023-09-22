using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_FluentValidation.Context;
using CohortHw_FluentValidation.Operations.CreateMovie;
using CohortHw_FluentValidation.Operations.DeleteMovie;
using CohortHw_FluentValidation.Operations.GetMovie;
using CohortHw_FluentValidation.Operations.UpdateMovie;
using CohortHw_FluentValidation.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CohortHw_FluentValidation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MovieDBContext _context;

        public MoviesController(MovieDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        
        // GET: api/Movies
        [HttpGet]
        public IActionResult GetMovies() { 
            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
            List<QueryViewModel> MovieList;
            try
            {
                MovieList = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(MovieList); 
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult CreateMovie([FromBody] CommandViewModel viewModel) { 
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper, viewModel);
            CreateMovieValidator validator = new CreateMovieValidator();
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }

        // PUT: api/Movies/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] CommandViewModel viewModel) { 
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper, id, viewModel);
            UpdateMovieValidator validator = new UpdateMovieValidator();
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }

        // DELETE: api/Movies/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id) { 
            DeleteMovieCommand command = new DeleteMovieCommand(_context, id);
            DeleteMovieValidator validator = new DeleteMovieValidator();
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }
    }
}