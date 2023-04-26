using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductorRequestController : Controller
    {
        private readonly IProductorRequestService _productorRequestService;
        private readonly IMapper _mapper;
        public ProductorRequestController(IProductorRequestService productorRequestService,IMapper mapper)
        {
            _productorRequestService = productorRequestService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListProductorRequest()
        {
            var response = _productorRequestService.GetAllProductorRequest();
            List<AdminProductorRequestViewModel> adminProductors = _mapper.Map<List<AdminProductorRequestViewModel>>(response);
            return Ok(adminProductors);
        }
    }
}
