using Cinemagnesia.Infrastructure.DataAccess.DbContext;
using Domain.Entities.Concrete;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
{
    public class MovieCommentRepository : BaseRepository<MovieComment>, IMovieCommentRepository
    {
        private readonly DbSet<MovieComment> _dbSet;
        public MovieCommentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = _dbContext.Set<MovieComment>();
        }

        public int GetNumOfMovieComments()
        {
            //Console.WriteLine(_dbSet.Count());
            return _dbSet.Count();
        }

        public List<MovieComment> GetAllComments()
        {
            return _dbContext.MovieComments.Include(m => m.Movie).Include(m => m.Movie.Genres).ToList();
        }
    }
}
