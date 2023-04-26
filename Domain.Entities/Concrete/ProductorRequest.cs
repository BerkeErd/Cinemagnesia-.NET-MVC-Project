using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class ProductorRequest : BaseEntity
    {
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Waiting;
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Email { get; set; }
        public DateTime ApplicationDate { get; set; } =  DateTime.Now;
        public string CompanyName { get; set; }
        public int TaxNumber { get; set; }
        public DateTime FoundDate { get; set; }

    }
}
