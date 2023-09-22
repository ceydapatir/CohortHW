using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CohortHw_FluentValidation.Operations.CreateMovie
{
    public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
    {
        // Data check rules for POST method
        public CreateMovieValidator(){
            RuleFor(i => i.ViewModel.Name).NotNull();
            RuleFor(i => i.ViewModel.Director).NotNull();
            RuleFor(i => i.ViewModel.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.ViewModel.PublishDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(i => i.ViewModel.ImageURL).NotNull();
            RuleFor(i => i.ViewModel.IMDB).NotEmpty().GreaterThan(0);
        }
    }
}