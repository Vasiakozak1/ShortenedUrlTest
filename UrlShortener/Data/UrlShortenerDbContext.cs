using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Data
{
    public class UrlShortenerDbContext: DbContext
    {
        public DbSet<ShortenedUrlEntry> UrlEntries { get; set; }

        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrlEntry>()
                .HasIndex(e => e.ShortUrl);

            base.OnModelCreating(modelBuilder);
        }
    }
}
