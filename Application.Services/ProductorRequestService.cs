using Application.Interfaces.AppInterfaces;
using Domain.Entities.Concrete;
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
        private readonly ProductorRequestRepository _productorRequestRepository;
        public void AddProductorRequest(ProductorRequest productorRequest)
        {
            _productorRequestRepository.CreateAsync(productorRequest).Wait();
        }

        public void DeleteProductorRequest(string id)
        {
            _productorRequestRepository.DeleteAsync(id).Wait();
        }

        public ProductorRequest GetProductorRequestById(string productorRequestId)
        {
            return _productorRequestRepository.GetByIdAsync(productorRequestId).Result;
        }

        public void UpdateProductorRequest(string id, ProductorRequest productorRequest)
        {
            _productorRequestRepository.UpdateAsync(id, productorRequest).Wait();
        }
    }
}
