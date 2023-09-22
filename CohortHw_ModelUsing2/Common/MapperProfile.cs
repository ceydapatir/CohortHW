using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CohortHw_ModelUsing2.Entities;
using static CohortHw_ModelUsing2.Operations.CreateMovie.CreateMovieCommand;
using static CohortHw_ModelUsing2.Operations.GetMovie.GetMovieDetailQuery;
using static CohortHw_ModelUsing2.Operations.UpdateMovie.UpdateMovieCommand;

namespace CohortHw_ModelUsing2.Common;

public class MapperProfile : Profile
{
    public MapperProfile(){
        CreateMap<Movie, GetMovieDetailViewModel>()
            .ForMember(i => i.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
            .ForMember(i => i.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyy")));
        CreateMap<CreateMovieViewModel, Movie>();
        CreateMap<UpdateMovieViewModel, Movie>().ReverseMap();
    }
}
