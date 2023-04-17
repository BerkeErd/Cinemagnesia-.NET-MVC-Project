using Cinemagnesia.Domain.Domain.Entities.Concrete;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinemagnesia.Infrastructure.DataAccess.DbContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    DbSet<CastMember> CastMembers { get; set; }
    DbSet<Company> Companies { get; set; }
    DbSet<CompanyUser> CompanyUsers { get; set; }
    DbSet<Director> Directors { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Movie> Movies { get; set; }
    DbSet<MovieComment> MoviesComments { get; set; }
    DbSet<ProductorRequest> ProductorRequests { get; set; }
    DbSet<Rating> Ratings { get; set; }
    DbSet<WatchList> WatchList { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
