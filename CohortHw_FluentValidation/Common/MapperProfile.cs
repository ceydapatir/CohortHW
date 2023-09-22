using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_FluentValidation.Entities;
using CohortHw_FluentValidation.Models;

namespace CohortHw_FluentValidation.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile(){
            CreateMap<Movie, QueryModel>() // map to get
                .ForMember(i => i.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
                .ForMember(i => i.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyy")));
            CreateMap<CommandModel, Movie>(); // map to create
            CreateMap<CommandModel, Movie>().ReverseMap(); // map to update
        }
    }
}