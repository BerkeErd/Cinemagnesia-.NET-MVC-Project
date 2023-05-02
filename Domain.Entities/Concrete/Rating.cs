using Cinemagnesia.Domain.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class Rating : BaseEntity
    {
       
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]

        [Range(0,6)]
        public int Score { get; set; }
    }
}
