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
    public class ProductorRequestMapper : Profile
    {
        public ProductorRequestMapper()
        {
            CreateMap<AddProductorRequestDto, ProductorRequest>();

            CreateMap<ProductorRequest, ProductorRequestDto>();

            CreateMap<ProductorRequestDto, ProductorRequest>();

        }
    }
}
