using Application.Dtos;
using Application.Interfaces.AppInterfaces;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
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
            if(productorRequest != null)
            {
                var addProductorRequest = _mapper.Map<ProductorRequest>(productorRequest);
                var response = _productorRequestRepository.CreateAsync(addProductorRequest).Result;
                var productorRequestDto = _mapper.Map<ProductorRequestDto>(response);
                return productorRequestDto;
            }

            return new ProductorRequestDto();
           
        }

        public void DeleteProductorRequest(string id)
        {
            if(id != null)
            {
                _productorRequestRepository.DeleteAsync(id).Wait();
            }
            
        }

        public List<ProductorRequestDto> GetAllProductorRequest()
        {
            var response = _productorRequestRepository.GetAllAsync().GetAwaiter().GetResult();
            if(response != null)
            {
                var productorRequests = _mapper.Map<List<ProductorRequestDto>>(response);
                if(productorRequests != null)
                {
                    return productorRequests;
                }
            }
            return new List<ProductorRequestDto>();

           
        }


        public ProductorRequestDto GetProductorRequestById(string productorRequestId)
        {
            if(productorRequestId != null)
            {
                var response = _productorRequestRepository.GetByIdAsync(productorRequestId).Result;
                if (response != null)
                {
                    var responseDTO = _mapper.Map<ProductorRequestDto>(response);
                    return responseDTO;
                }
            }

            return new ProductorRequestDto();


        }

        public void UpdateProductorRequest(string id, ProductorRequestDto productorRequestDto)
        {
            if(id != null && productorRequestDto != null)
            {
                var productorRequest = _mapper.Map<ProductorRequest>(productorRequestDto);
                _productorRequestRepository.Update(id, productorRequest);
            }
            
        }

        public List<ProductorRequestDto> GetNumOfApprovedProductorRequests()
        {
            var response = _productorRequestRepository.GetAllAsync().GetAwaiter().GetResult();
            if(response != null)
            {
                var productorRequests = _mapper.Map<List<ProductorRequestDto>>(response);

                var approvedProductors = productorRequests.Where(productorRequest => productorRequest.ApprovalStatus == ApprovalStatus.Approved).ToList();


                return approvedProductors;
            }

            return new List<ProductorRequestDto>();
          
        }
    }
}
