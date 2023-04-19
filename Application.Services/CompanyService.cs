using Application.Interfaces.AppInterfaces;
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
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void AddCompany(Company company)
        {
            _companyRepository.CreateAsync(company).Wait();
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
            _companyRepository.UpdateAsync(id, company).Wait();
        }
    }
}
