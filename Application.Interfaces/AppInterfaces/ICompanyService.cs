using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        void AddCompany(Company company);
        void RemoveCompany(string id);
        void UpdateCompany(string id, Company company);
        Company GetById(string id);
    }
}
