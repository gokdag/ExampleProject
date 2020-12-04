using ExampleProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using ExampleProject.Data.Configurations;

namespace ExampleProject.Data
{
    public class MusicMarketDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public MusicMarketDbContext(DbContextOptions<MusicMarketDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MusicConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }

    }
}
