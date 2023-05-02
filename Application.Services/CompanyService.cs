using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public AddCompanyDto AddCompany(AddCompanyDto addCompanyDto)
        {
            var company = _mapper.Map<Company>(addCompanyDto);
            var response = _companyRepository.CreateAsync(company).GetAwaiter().GetResult();

            var companydto = _mapper.Map<AddCompanyDto>(response);
            return companydto;

        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _companyRepository.GetAllAsync().Result;
        }

        public Company GetById(string id)
        {
            return _companyRepository.GetByIdAsync(id).Result;
        }

        public void RemoveCompany(string id)
        {
            _companyRepository.DeleteAsync(id).Wait();
        }

        public void UpdateCompany(string id, Company company)
        {
            _companyRepository.Update(id, company);
        }

        public int GetNumOfCompanies()
        {
            return _companyRepository.GetNumOfCompanies();
        }
    }
}
