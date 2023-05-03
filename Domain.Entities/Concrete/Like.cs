using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class Like : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
