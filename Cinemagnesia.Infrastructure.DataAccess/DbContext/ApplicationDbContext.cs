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

    public DbSet<CastMember> CastMembers { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieComment> MoviesComments { get; set; }
    public DbSet<ProductorRequest> ProductorRequests { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<WatchList> WatchList { get; set; }
    public DbSet<MovieComment> MovieComments { get; set; }
    public DbSet<UserRestriction> UserRestrictions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.RatedUsers)
            .WithMany(u => u.RatedMovies)
            .UsingEntity<Rating>(
                r => r.HasOne(r => r.User)
                      .WithMany()
                      .HasForeignKey(r => r.ApplicationUserId),
                r => r.HasOne(r => r.Movie)
                      .WithMany()
                      .HasForeignKey(r => r.MovieId),
                r => r.HasKey(r => new { r.ApplicationUserId, r.MovieId })
            );

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.FavoritedUsers)
            .WithMany(u => u.FavoriteMovies)
            .UsingEntity<Like>(
                r => r.HasOne(l => l.User)
                      .WithMany()
                      .HasForeignKey(l => l.ApplicationUserId),
                r => r.HasOne(l => l.Movie)
                      .WithMany()
                      .HasForeignKey(l => l.MovieId),
                r => r.HasKey(l => new { l.ApplicationUserId, l.MovieId })
            );

        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Company)
            .WithMany(c => c.Movies)
            .HasForeignKey(m => m.CompanyId);

    }

}

