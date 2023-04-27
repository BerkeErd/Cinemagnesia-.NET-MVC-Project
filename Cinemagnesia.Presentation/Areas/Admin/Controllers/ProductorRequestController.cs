using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Cinemagnesia.Presentation.Areas.Admin.Models;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
using Infrastructure.DataAccess.Migrations;
using Infrastructure.Email.Customs.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinemagnesia.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductorRequestController : Controller
    {
        private readonly IProductorRequestService _productorRequestService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICustomEmailSender _EmailSender;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public ProductorRequestController(IProductorRequestService productorRequestService,IMapper mapper, ICompanyService companyService, UserManager<ApplicationUser> userManager, ICustomEmailSender EmailSender)
        {
            _EmailSender = EmailSender;
            _userManager = userManager;
            _productorRequestService = productorRequestService;
            _mapper = mapper;
            _companyService = companyService;
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

        [HttpPost]
        public async Task<IActionResult> ApproveProductorRequest(string id) 
        {
           ProductorRequestDto productRequestDto = _productorRequestService.GetProductorRequestById(id);
            // ID'ye göre Request bulunacak. 
            if(productRequestDto.ApprovalStatus != ApprovalStatus.Approved)
            {
                try
                {
                    productRequestDto.ApprovalStatus = ApprovalStatus.Approved;
                    // Request Statusu Approved olacak.
                    _productorRequestService.UpdateProductorRequest(id, productRequestDto);
                    AddCompanyDto companyDto = new AddCompanyDto();
                    companyDto.Name = productRequestDto.CompanyName;
                    companyDto.TaxNumber = productRequestDto.TaxNumber;
                    companyDto.FoundDate = productRequestDto.FoundDate;
                    // Request'in içindeki Company bilgileri Company tablosuna eklenecek.
                    AddCompanyDto company = _companyService.AddCompany(companyDto);
                    // Request'in içindeki UserID'den User bulunacak.
                    ApplicationUser user = await _userManager.FindByIdAsync(productRequestDto.ApplicationUserId);
                    // User'a eklenen company'nin IDsi CompanyID olarak eklenecek.
                    user.CompanyId = company.Id;
                    await _userManager.UpdateAsync(user);
                    // User'ın Rolü Productor olarak değiştirilecek.
                    await _userManager.RemoveFromRoleAsync(user, "User");
                    await _userManager.AddToRoleAsync(user, "Productor");

                    // User'a Mail gönderilecek.
                    await _EmailSender.SendProductorRequestApprovedEmailAsync(user.Email); // SIKINTILI
                    return Ok("Onaylandı");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                    throw;
                }
               
            }
            else
            {
                return Ok("Başarısız");
            }
            
        }
        public async Task<IActionResult> RejectProductorRequest(string id)
        {
            ProductorRequestDto productRequestDto = _productorRequestService.GetProductorRequestById(id);
            if (productRequestDto.ApprovalStatus != ApprovalStatus.Approved)
            {
                try
                {
                    // ID'ye göre Request bulunacak. 
                    productRequestDto.ApprovalStatus = ApprovalStatus.Rejected;
                    _productorRequestService.UpdateProductorRequest(id, productRequestDto);
                    // Request Statusu Rejected olacak.
                    ApplicationUser user = await _userManager.FindByIdAsync(productRequestDto.ApplicationUserId);
                    await _EmailSender.SendProductorRequestRejectedEmailAsync(user.Email); // SIKINTILI
                                                                                           // User'a Mail gönderilecek.
                    return Ok("Başarıyla reddedildi.");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                    throw;
                }
               
            }
            else
            {
                return Ok("Başarıyla reddedilemedi.");
            }
        }
    }
}
