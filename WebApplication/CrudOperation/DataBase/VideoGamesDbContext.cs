using Microsoft.EntityFrameworkCore;

namespace CrudOperation.DataBase
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        public async Task<List<VideoGame>> GetAllVideoGamesFromSP()
        {
            return await VideoGames.FromSqlRaw("EXEC GetVideoGames").ToListAsync();
        }
    }
}
