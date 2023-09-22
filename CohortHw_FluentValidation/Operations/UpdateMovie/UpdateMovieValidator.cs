using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CohortHw_FluentValidation.Operations.UpdateMovie
{
    public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
    {
        // Data check rules for PUT method
        public UpdateMovieValidator(){
            RuleFor(i => i.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.ViewModel.Name).NotNull();
            RuleFor(i => i.ViewModel.Director).NotNull();
            RuleFor(i => i.ViewModel.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.ViewModel.PublishDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(i => i.ViewModel.ImageURL).NotNull();
            RuleFor(i => i.ViewModel.IMDB).NotEmpty().GreaterThan(0);
        }
    }
}