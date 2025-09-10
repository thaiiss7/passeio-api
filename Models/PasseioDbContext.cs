using Microsoft.EntityFrameworkCore;

namespace Passeio.Models;

public class PasseioDbContext(DbContextOptions<PasseioDbContext> options) : DbContext(options)
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<TourStop> TourStops => Set<TourStop>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Profile>();

        model.Entity<Tour>()
            .HasOne(t => t.Author)
            .WithMany(a => a.Tours)
            .HasForeignKey(t => t.ProfileId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<TourStop>()
            .HasMany(s => s.Tours)
            .WithMany(t => t.TourStops)
            .UsingEntity("TourItem");
    }
}