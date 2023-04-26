using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cinemagnesia.Presentation.Controllers
{
    [Authorize("User")]
    public class ProductorRequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductorRequestService _productorRequestService;

        public ProductorRequestController(IMapper mapper ,IProductorRequestService productorRequestService)
        {
            _mapper = mapper;
            _productorRequestService = productorRequestService;
        }
        
        public IActionResult Index()
        {
            ViewBag.response = TempData["response"];
            return View();
            
        }
        public IActionResult CreateProductorRequest(AddProductorRequestViewModel productorRequestViewModel)
        {
           
            if (ModelState.IsValid)
            {
                AddProductorRequestDto addProductorRequestDto = _mapper.Map<AddProductorRequestDto>(productorRequestViewModel);
                var response = _productorRequestService.AddProductorRequest(addProductorRequestDto);
                UserProductorRequestViewModel model = _mapper.Map<UserProductorRequestViewModel>(response);

                TempData["response"] = JsonConvert.SerializeObject(model);

                return RedirectToAction("Index");


            }
            return Ok("Eklenmedi");
        }
    }
}
