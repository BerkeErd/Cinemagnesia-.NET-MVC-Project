using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public  class ProductorRequestDto
    {
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public DateTime FoundDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
