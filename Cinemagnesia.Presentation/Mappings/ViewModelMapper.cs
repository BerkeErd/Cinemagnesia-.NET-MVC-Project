using Application.Dtos;
using AutoMapper;
using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Cinemagnesia.Presentation.Mappings
{
    public class ViewModelMapper : Profile
    {
        private readonly ApplicationDbContext _dbContext;
        public ViewModelMapper(ApplicationDbContext dbContext)

        {
            _dbContext = dbContext;

            CreateMap<AddMovieDto, AddMovieViewModel>();

            CreateMap<AddMovieViewModel, AddMovieDto>()
                   .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(d =>
                        _dbContext.Directors.FirstOrDefault(x => x.Name == d.Name) ?? new Director { Name = d.Name }
                    )))
                    .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g =>
                        _dbContext.Genres.FirstOrDefault(x => x.Name == g.Name) ?? new Genre { Name = g.Name }
                    )))
                    .ForMember(dest => dest.CastMembers, opt => opt.MapFrom(src => src.CastMembers.Select(c =>
                        _dbContext.CastMembers.FirstOrDefault(x => x.Name == c.Name) ?? new CastMember { Name = c.Name }
                    )));
            CreateMap<GenreDto, GenreViewModel>();

            CreateMap<GenreViewModel, GenreDto>();

            CreateMap<AddGenreViewModel, GenreDto>();

            CreateMap<GenreDto, AddGenreViewModel>();

            CreateMap<AddProductorRequestViewModel, AddProductorRequestDto>();
            CreateMap<ProductorRequestDto, UserProductorRequestViewModel>();

            CreateMap<ProductorRequestDto, AdminProductorRequestViewModel>();
            CreateMap<AdminProductorRequestViewModel, ProductorRequestDto>();
        }
    }
}
