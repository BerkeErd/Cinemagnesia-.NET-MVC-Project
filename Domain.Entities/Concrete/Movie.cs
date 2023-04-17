using Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Range(0, 10f)]
        public float ImdbRating { get; set; }
        [Range(0, 10f)]
        public float CinemagAvgScore { get; set; }
        public Status Status { get; set; }
        public string TrailerUrl { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<CastMembers> CastMembers { get; set; }
        public ICollection<MovieComment> MovieComments { get; set; }
        public ICollection<User> WatchedUsers { get; set; }
        public ICollection<User> RatedUsers { get; set; }
        public ICollection<User> WantToWatchUsers { get; set; }

    }
}
