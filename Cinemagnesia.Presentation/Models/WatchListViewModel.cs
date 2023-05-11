using Domain.Entities.Constants;

namespace Cinemagnesia.Presentation.Models
{
    public class WatchListViewModel
    {
            public string MovieId { get; set; }
            public string MovieTitle { get; set; }
            public WatchStatus WatchStatus { get; set; }
            public int? Rating { get; set; }
            public string PosterUrl { get; set; }
        
    }
}
