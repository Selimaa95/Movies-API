using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace Movies.BL.Services.Genres
{
    public class GenresService : IGenresService
    {

        #region Prop

        private readonly ApplicationDbContext db;

        #endregion

        #region Ctor
        public GenresService(ApplicationDbContext db)
        {
            this.db = db;
        }

        #endregion

        #region Actions

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            var genre = await db.Genres.OrderBy(g => g.Name).ToListAsync();
            return genre;
        }

        public async Task<Genre> GetByIdAsync(byte id)
        {
            var genre = await db.Genres.SingleOrDefaultAsync(g => g.Id == id);
            return genre;
        }

        public async Task<Genre> CreateAsync(Genre genre)
        {
            await db.Genres.AddAsync(genre);
            await db.SaveChangesAsync();
            return genre;
        }

        public Genre Update(Genre genre)
        {
            db.Update(genre);
            db.SaveChanges();
            return genre;
        }

        public Genre Delete(Genre genre)
        {
            db.Remove(genre);
            db.SaveChanges();
            return genre;
        }

        public async Task<bool> IsValidGenre(byte id)
        {
            return await db.Genres.AnyAsync(g => g.Id == id);
        }

        #endregion
    }
}
