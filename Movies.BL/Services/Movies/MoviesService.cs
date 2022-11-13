using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Dtos;
using MoviesAPI.Models;

namespace Movies.BL.Services.Movies
{
    public class MoviesService : IMoviesService
    {

        #region Prop

        private readonly ApplicationDbContext db;

        #endregion

        #region Ctor

        public MoviesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        #endregion

        #region Actions

        public async Task<IEnumerable<Movie>> GetAllAsync(byte genreId = 0)
        {
            return await db.Movies
           .Where(m => m.GenreId == genreId || genreId == 0)
           .OrderByDescending(x => x.Rate)
           .Include(g => g.Genre)
           .ToListAsync();
        }


        public async Task<Movie> GetByIdAsync(int id)
        {
            return await db.Movies.Include(m => m.Genre).SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            await db.Movies.AddAsync(movie);
            await db.SaveChangesAsync();

            return movie;
        }

        public Movie Update(Movie movie)
        {
            db.Movies.Update(movie);
            db.SaveChangesAsync();

            return movie;
        }

        public Movie Delete(Movie movie)
        {
            db.Movies.Remove(movie);
            db.SaveChangesAsync();

            return movie;
        }




        #endregion
    }
}
