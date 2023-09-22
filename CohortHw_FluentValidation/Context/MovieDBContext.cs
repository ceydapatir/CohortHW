using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CohortHw_FluentValidation.Entities;
using Microsoft.EntityFrameworkCore;

namespace CohortHw_FluentValidation.Context
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options) {}

        public DbSet<Movie> Movies { get; set;}
    }
}