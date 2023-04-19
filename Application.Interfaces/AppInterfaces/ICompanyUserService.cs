using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface ICompanyUserService
    {
        IEnumerable<CompanyUser> GetAllCompanyUsers();
        void AddCompanyUser(CompanyUser companyUser);
        void RemoveCompanyUser(string id);
        void UpdateCompanyUser(string id, CompanyUser companyUser);
        CompanyUser GetById(string id);
    }
}
