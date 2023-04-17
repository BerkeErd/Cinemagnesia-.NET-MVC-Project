using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class WatchList : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        public WatchStatus WatchStatus { get; set; } = WatchStatus.None;

    }
}
