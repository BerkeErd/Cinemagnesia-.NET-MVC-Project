using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpGet]
        public int GetNumOfCompanies()
        {
            return _companyService.GetNumOfCompanies();
        }

    }
}
