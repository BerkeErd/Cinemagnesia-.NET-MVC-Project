using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
