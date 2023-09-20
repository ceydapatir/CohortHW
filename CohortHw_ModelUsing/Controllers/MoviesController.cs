using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CohortHw_ModelUsing.Context;
using CohortHw_ModelUsing.Operations.GetMovie;
using static CohortHw_ModelUsing.Operations.CreateMovie.CreateMovieCommand;
using CohortHw_ModelUsing.Operations.CreateMovie;
using System.Linq.Expressions;

namespace CohortHw_ModelUsing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMovies(){
            GetMoviesQuery query = new GetMoviesQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id){
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context);
            query.MovieId = id;
            var result = query.Handle();
            if(result is null){
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieViewModel movie){
            try
            {
                CreateMovieCommand query = new CreateMovieCommand(_context);
                query.CreateModel = movie;
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
