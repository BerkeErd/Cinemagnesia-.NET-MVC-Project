using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class AddCompanyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public DateTime FoundDate { get; set; }
    }
}
