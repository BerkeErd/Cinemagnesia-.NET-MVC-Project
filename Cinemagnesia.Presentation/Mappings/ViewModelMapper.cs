using Application.Dtos;
using AutoMapper;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Cinemagnesia.Presentation.Models;

namespace Cinemagnesia.Presentation.Mappings
{
    public class ViewModelMapper : Profile
    {
        public ViewModelMapper()
        {
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
