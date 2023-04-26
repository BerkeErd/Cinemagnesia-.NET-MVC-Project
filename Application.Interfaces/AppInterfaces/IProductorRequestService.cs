using Application.Dtos;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AppInterfaces
{
    public interface IProductorRequestService
    {
        ProductorRequest GetProductorRequestById(string productorRequestId);
        ProductorRequestDto AddProductorRequest(AddProductorRequestDto productorRequest);

        List<ProductorRequestDto> GetAllProductorRequest();
        void DeleteProductorRequest(string id);
        void UpdateProductorRequest(string id, ProductorRequest productorRequest);  
    }
}
