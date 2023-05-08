using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Presentation.Models;
using Domain.Entities.Concrete;
using Infrastructure.Email.Customs.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Cinemagnesia.Presentation.Controllers
{
    
    public class ProductorRequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICustomEmailSender _emailSender;
        private readonly IProductorRequestService _productorRequestService;

        public ProductorRequestController(IMapper mapper, IProductorRequestService productorRequestService, ICustomEmailSender emailSender)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _productorRequestService = productorRequestService;
        }
        [Authorize("User")]
        public IActionResult Index()
        {
            ViewBag.response = TempData["response"];
            return View();

        }
        [Authorize("User")]
        public IActionResult CreateProductorRequest(AddProductorRequestViewModel productorRequestViewModel)
        {
            List<ProductorRequestDto> productorRequestDtos = _productorRequestService.GetAllProductorRequest();
            var productorRequest = productorRequestDtos.Find(x => x.Email == productorRequestViewModel.Email);
            UserProductorRequestViewModel errorMessage = new UserProductorRequestViewModel();
            errorMessage.Code = 400;
            if (productorRequest == null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        AddProductorRequestDto addProductorRequestDto = _mapper.Map<AddProductorRequestDto>(productorRequestViewModel);
                        var response = _productorRequestService.AddProductorRequest(addProductorRequestDto);
                        UserProductorRequestViewModel model = _mapper.Map<UserProductorRequestViewModel>(response);
                        model.Code = 200;
                        TempData["response"] = JsonConvert.SerializeObject(model);
                        _emailSender.SendProductorRequestCreatedEmailAsync(addProductorRequestDto.Email);
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    { 
                        errorMessage.Message = e.Message;
                        throw e;
                        TempData["response"] = JsonConvert.SerializeObject(errorMessage);
                        return RedirectToAction("Index");
                    }



                }
                List<string> errors = new List<string>();
                foreach (ModelStateEntry modelStateEntry in ModelState.Values)
                {
                    foreach (ModelError error in modelStateEntry.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(errors);
            }
            else
            {
                errorMessage.Message = "Zaten daha önce başvuru yapmışsınız.";
                TempData["response"] = JsonConvert.SerializeObject(errorMessage);
                return RedirectToAction("Index");
            }


        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public int GetNumOfApprovedProductors()
        {
            return _productorRequestService.GetNumOfApprovedProductorRequests().Count();
        }
    }
}
