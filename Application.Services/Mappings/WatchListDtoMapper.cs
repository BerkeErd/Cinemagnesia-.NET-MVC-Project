using Application.Dtos;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Mappings
{
    public class WatchListDtoMapper : Profile
    {
        public WatchListDtoMapper()
        {
            CreateMap<WatchList, WatchListDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
              .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
              .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Title))
              .ForMember(dest => dest.MovieImage, opt => opt.MapFrom(src => src.Movie.PosterPath))
              .ForMember(dest => dest.WatchStatus, opt => opt.MapFrom(src => src.WatchStatus))
              .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => (int?)null));

            CreateMap<WatchListDto, WatchList>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.WatchStatus, opt => opt.MapFrom(src => src.WatchStatus));

        }
    }
}