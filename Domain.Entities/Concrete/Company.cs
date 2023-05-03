using Cinemagnesia.Domain.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class Company : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string TaxNumber { get; set; }
        public DateTime FoundDate { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<ApplicationUser> Workers { get; set; }
    }
}
