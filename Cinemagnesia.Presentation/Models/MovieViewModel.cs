using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Concrete;
using Domain.Entities.Constants;
using System.ComponentModel.DataAnnotations;

namespace Cinemagnesia.Presentation.Models
{
    public class MovieViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        [MaxLength(5000)]
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Range(0, 10f)]
        public float ImdbRating { get; set; }
        [Range(0, 10f)]
        public float CinemagAvgScore { get; set; }
        public string TrailerUrl { get; set; }
        public ApprovalStatus Status { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<CastMember> CastMembers { get; set; }
        public ICollection<MovieComment> MovieComments { get; set; }
        public ICollection<ApplicationUser> LikedUsers { get; set; }
        public int MovieMinutes { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
