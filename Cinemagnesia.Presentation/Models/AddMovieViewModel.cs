namespace Cinemagnesia.Presentation.Models
{
	public class AddMovieViewModel
	{
		public int CompanyId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string PosterPath { get; set; }
		public DateTime ReleaseDate { get; set; }
		public float ImdbRating { get; set; }
		public string TrailerUrl { get; set; }
		public List<string> Directors { get; set; }
		public List<string> Genres { get; set; }
		public List<string> CastMembers { get; set; }
		public int MovieMinute { get; set; }
		public string Language { get; set; }
	}
}
