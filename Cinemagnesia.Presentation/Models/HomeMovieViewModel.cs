using Domain.Entities.Concrete;
using System.Collections.Specialized;

namespace Cinemagnesia.Presentation.Models
{
    public class HomeMovieViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public float ImdbRating { get; set; }
        public ICollection<Genre> Genres { get; set; }

    }
}
