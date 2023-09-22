using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CohortHw_FluentValidation.Operations.DeleteMovie
{
    public class DeleteMovieValidator : AbstractValidator<DeleteMovieCommand>
    {
        // Data check rules for DELETE method
        public DeleteMovieValidator(){
            RuleFor(i => i.MovieId).NotEmpty().GreaterThan(0);
        }
    }
}