using ExampleProject.Core.Models;
using ExampleProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleProject.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {


        public ArtistRepository(MusicMarketDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await MusicMarketDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return MusicMarketDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private MusicMarketDbContext MusicMarketDbContext
        {
            get { return Context as MusicMarketDbContext; }
        }
    }
}
