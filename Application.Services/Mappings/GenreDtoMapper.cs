using Application.Dtos;
using AutoMapper;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Mappings
{
    public class GenreDtoMapper : Profile
    {
        public GenreDtoMapper() 
        {
            CreateMap<GenreDto, Genre>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Genre, GenreDto>();

            CreateMap<Genre, GenreStatisticDto>().ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.Movies.Count));
        }
    }
}
