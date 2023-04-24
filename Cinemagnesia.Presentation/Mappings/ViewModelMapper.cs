using Application.Dtos;
using AutoMapper;
using Cinemagnesia.Presentation.Areas.Admin.Models;

namespace Cinemagnesia.Presentation.Mappings
{
    public class ViewModelMapper : Profile
    {
        public ViewModelMapper()
        {
            CreateMap<GenreDto, GenreViewModel>();

            CreateMap<AddGenreViewModel, GenreDto>();
            
        }
    }
}
