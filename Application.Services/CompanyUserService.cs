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
    public class CompanyUserService : ICompanyUserService
    {
        private readonly ICompanyUserRepository _companyUserRepository;

        public CompanyUserService(ICompanyUserRepository companyUserRepository)
        {
            _companyUserRepository = companyUserRepository;
        }

        public void AddCompanyUser(CompanyUser companyUser)
        {
            _companyUserRepository.CreateAsync(companyUser).Wait();
        }

        public IEnumerable<CompanyUser> GetAllCompanyUsers()
        {
            return _companyUserRepository.GetAllAsync().Result;
        }

        public CompanyUser GetById(string id)
        {
            return _companyUserRepository.GetByIdAsync(id).Result;
        }

        public void RemoveCompanyUser(string id)
        {
            _companyUserRepository.GetByIdAsync(id).Wait();
        }

        public void UpdateCompanyUser(string id, CompanyUser companyUser)
        {
            _companyUserRepository.UpdateAsync(id, companyUser).Wait();
        }
    }
}
