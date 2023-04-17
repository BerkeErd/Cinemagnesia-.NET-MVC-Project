using Cinemagnesia.Domain.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class CompanyUser : BaseEntity
    {
        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }
        [Required]
        public string CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
