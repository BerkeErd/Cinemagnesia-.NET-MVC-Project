using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public  class UpdateMovieDto
    {
        public ApprovalStatus Status { get; set; }
    }
}
