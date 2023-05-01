using Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyId { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float ImdbRating { get; set; }
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Waiting;
        public string TrailerUrl { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<CastMember> CastMembers { get; set; }
        public int MovieMinutes { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
