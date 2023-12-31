using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohortHw_FluentValidation.Models
{
    public class QueryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public double IMDB { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public string ImageURL { get; set; }
    }
}