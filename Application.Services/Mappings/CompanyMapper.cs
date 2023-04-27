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
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<AddCompanyDto, Company>().ForMember(dest => dest.Id, opt => opt.Ignore()); 

            CreateMap<Company, AddCompanyDto>();

        }
    }
}
