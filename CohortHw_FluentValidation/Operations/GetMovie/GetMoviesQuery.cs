using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_FluentValidation.Context;
using CohortHw_FluentValidation.Entities;
using CohortHw_FluentValidation.Models;

namespace CohortHw_FluentValidation.Operations.GetMovie
{
    public class GetMoviesQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieDBContext _context;
        public GetMoviesQuery(MovieDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        // Get all movies, if there is no movie, throw an error
        public List<QueryModel> Handle(){
            var MovieList = _context.Movies.OrderBy(i => i.Id).ToList<Movie>();
            List<QueryModel> ViewModelList = new List<QueryModel>();
            QueryModel ViewModel;
            if(MovieList is null)
                throw new InvalidOperationException("There are no movies.");
            else
                foreach (var movie in MovieList)
                {
                    ViewModel = _mapper.Map<QueryModel>(movie); // Convert movie from Movie to QueryViewModel type
                    ViewModelList.Add(ViewModel);
                }
            return ViewModelList;       
        }
    }
}