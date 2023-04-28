﻿using Application.Dtos;
using AutoMapper;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Mappings
{
    public class MovieDtoMapper : Profile
    {
        public MovieDtoMapper()
        {
            CreateMap<Movie, AddMovieDto>();

            CreateMap<AddMovieDto, Movie>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
        
    }
}
