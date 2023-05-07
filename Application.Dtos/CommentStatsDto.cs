using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CommentStatsDto
    {
        public string GenreName { get; set; }
        public string MovieName { get; set; }

        public int CommentCount { get; set; }

    }
}
