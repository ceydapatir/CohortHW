using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohortHw_FluentValidation.ViewModels
{
    public class CommandViewModel
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public double IMDB { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageURL { get; set; }
    }
}