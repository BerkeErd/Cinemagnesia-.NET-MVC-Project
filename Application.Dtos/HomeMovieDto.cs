using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class HomeMovieDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public float ImdbRating { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
