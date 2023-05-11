using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class WatchListDto
    {
            public string Id { get; set; }
            public string ApplicationUserId { get; set; }
            public string MovieId { get; set; }
            public string MovieName { get; set; }
            public string MovieImage { get; set; }
            public WatchStatus WatchStatus { get; set; }
            public int? Rating { get; set; }
    }
}
