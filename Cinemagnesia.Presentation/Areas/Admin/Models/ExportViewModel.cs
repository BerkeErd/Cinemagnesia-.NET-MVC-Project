using Domain.Entities.Concrete;

namespace Cinemagnesia.Presentation.Areas.Admin.Models
{
    public class ExportViewModel
    {
        public IEnumerable<Movie> movies;
        public IEnumerable<Director> directors;

    }
}
