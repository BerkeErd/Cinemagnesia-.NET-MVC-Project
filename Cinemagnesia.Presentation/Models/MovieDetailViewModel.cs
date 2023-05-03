using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;

namespace Cinemagnesia.Presentation.Models
{
    public class MovieDetailViewModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float ImdbRating { get; set; }
        public float CinemagAvgScore { get; set; }
        public ApprovalStatus Status { get; set; } 
        public string TrailerUrl { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<CastMember> CastMembers { get; set; }
        public ICollection<MovieComment> MovieComments { get; set; }
        public ICollection<ApplicationUser> FavoritedUsers { get; set; }

        public ICollection<ApplicationUser> RatedUsers { get; set; }
        public int MovieMinutes { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
    }
}
