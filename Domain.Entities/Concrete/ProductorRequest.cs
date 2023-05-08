using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(20)]
        public string TaxNumber { get; set; }
        public DateTime FoundDate { get; set; }

    }
}
