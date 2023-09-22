using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_FluentValidation.Entities;
using CohortHw_FluentValidation.ViewModels;

namespace CohortHw_FluentValidation.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile(){
            CreateMap<Movie, QueryViewModel>() // map to get
                .ForMember(i => i.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
                .ForMember(i => i.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyy")));
            CreateMap<CommandViewModel, Movie>(); // map to create
            CreateMap<CommandViewModel, Movie>().ReverseMap(); // map to update
        }
    }
}