namespace Cinemagnesia.Presentation.Models
{
    public class AddMovieViewModel
    {
        public string CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float ImdbRating { get; set; }
        public string TrailerUrl { get; set; }
        public List<AddDirectorViewModel> Directors { get; set; }
        public List<AddGenreToMovieViewModel> Genres { get; set; }
        public List<AddCastMemberViewModel> CastMembers { get; set; }
        public int MovieMinutes { get; set; }
        public string Language { get; set; }
    }
}
