using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductorRequestService : IProductorRequestService
    {
        private readonly IMapper _mapper;
        private readonly IProductorRequestRepository _productorRequestRepository;

        public ProductorRequestService(IMapper mapper, IProductorRequestRepository productorRequestRepository)
        {
            _mapper = mapper;
            _productorRequestRepository = productorRequestRepository;
        }

        public ProductorRequestDto AddProductorRequest(AddProductorRequestDto productorRequest)
        {
            // eklenecek dto ile entity maplenmesi
            var addProductorRequest = _mapper.Map<ProductorRequest>(productorRequest);
            var response = _productorRequestRepository.CreateAsync(addProductorRequest).Result;
            // dönen entity ile dönüş dto'nun maplenmesi
            var productorRequestDto = _mapper.Map<ProductorRequestDto>(response);
            return productorRequestDto;
        }

        public void DeleteProductorRequest(string id)
        {
            _productorRequestRepository.DeleteAsync(id).Wait();
        }

        public List<ProductorRequestDto> GetAllProductorRequest()
        {
            var response = _productorRequestRepository.GetAllAsync().GetAwaiter().GetResult();
            var productorRequests = _mapper.Map<List<ProductorRequestDto>>(response);

            return productorRequests;
        }


        public ProductorRequestDto GetProductorRequestById(string productorRequestId)
        {
            var response = _productorRequestRepository.GetByIdAsync(productorRequestId).Result;
            var responseDTO = _mapper.Map<ProductorRequestDto>(response);

            return responseDTO;
        }

        public void UpdateProductorRequest(string id, ProductorRequestDto productorRequestDto)
        {
            
            var productorRequest = _mapper.Map<ProductorRequest>(productorRequestDto);

            _productorRequestRepository.UpdateAsync(id, productorRequest).Wait();
        }
    }
}
