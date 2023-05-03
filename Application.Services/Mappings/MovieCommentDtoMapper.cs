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
    public class MovieCommentDtoMapper : Profile
    {
        public MovieCommentDtoMapper()
        {
            CreateMap<MovieCommentDto, MovieComment>();
            CreateMap<MovieComment, MovieCommentDto>();

            CreateMap<SendMovieCommentDto, MovieComment>();
            CreateMap<MovieComment, SendMovieCommentDto>();
        }
    }
}
