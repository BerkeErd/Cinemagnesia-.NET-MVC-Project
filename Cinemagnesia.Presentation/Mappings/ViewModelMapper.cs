using Application.Dtos;
using AutoMapper;
using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cinemagnesia.Presentation.Mappings
{
    public class ViewModelMapper : Profile
    {

        public ViewModelMapper()
        {

            CreateMap<AddMovieDto, AddMovieViewModel>();

            CreateMap<AddMovieViewModel, AddMovieDto>()
            .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(d => new Director { Name = d.Name })))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => new Genre { Name = g.Name })))
            .ForMember(dest => dest.CastMembers, opt => opt.MapFrom(src => src.CastMembers.Select(c => new CastMember { Name = c.Name })));
            CreateMap<GenreDto, GenreViewModel>();

            CreateMap<GenreViewModel, GenreDto>();

            CreateMap<AddGenreViewModel, GenreDto>();

            CreateMap<GenreDto, AddGenreViewModel>();

            CreateMap<AddProductorRequestViewModel, AddProductorRequestDto>();
            CreateMap<ProductorRequestDto, UserProductorRequestViewModel>();

            CreateMap<ProductorRequestDto, AdminProductorRequestViewModel>();
            CreateMap<AdminProductorRequestViewModel, ProductorRequestDto>();

            CreateMap<MovieDetailViewModel, MovieDto>();
            CreateMap<MovieDto, MovieDetailViewModel>();

            CreateMap<MovieDto, MovieViewModel>();
            CreateMap<MovieViewModel, MovieDto>();

            CreateMap<SendCommentViewModel, SendMovieCommentDto>();
            CreateMap<SendMovieCommentDto, SendCommentViewModel>();

            CreateMap<WatchListDto, WatchListViewModel>()
            .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
            .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.MovieName))
            .ForMember(dest => dest.WatchStatus, opt => opt.MapFrom(src => src.WatchStatus))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
            .ForMember(dest => dest.PosterUrl, opt => opt.MapFrom(src => src.MovieImage));
            CreateMap<WatchListViewModel, WatchListDto>();

        }
    }

   

}
