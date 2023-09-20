using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CohortHw_ModelUsing2.Context;
using CohortHw_ModelUsing2.Operations.GetMovie;
using static CohortHw_ModelUsing2.Operations.CreateMovie.CreateMovieCommand;
using CohortHw_ModelUsing2.Operations.CreateMovie;
using static CohortHw_ModelUsing2.Operations.UpdateMovie.UpdateMovieCommand;
using CohortHw_ModelUsing2.Operations.UpdateMovie;
using System.Linq.Expressions;
using AutoMapper;
using CohortHw_ModelUsing2.Operations.DeleteMovie;

namespace CohortHw_ModelUsing2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies(){
            GetMoviesQuery query = new GetMoviesQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id){
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = id;
            var result = query.Handle();
            if(result is null){
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieViewModel movie){
            CreateMovieCommand query = new CreateMovieCommand(_context, _mapper);
            try
            {
                query.CreateModel = movie;
                query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieViewModel movie){
            UpdateMovieCommand query = new UpdateMovieCommand(_context, _mapper);
            try
            {
                query.MovieId = id;
                query.UpdateModel = movie;
                query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveMovie(int id){
            DeleteMovieCommand query = new DeleteMovieCommand(_context);
            try
            {
                query.MovieId = id;
                query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}