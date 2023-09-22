using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CohortHw_FluentValidation.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public double IMDB { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageURL { get; set; }
    }
}