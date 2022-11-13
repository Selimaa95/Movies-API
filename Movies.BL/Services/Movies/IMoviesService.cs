using MoviesAPI.Data;
using MoviesAPI.Models;

namespace Movies.BL.Services.Movies
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> GetAllAsync(byte genreId = 0);
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> CreateAsync(Movie movie);
        Movie Update(Movie movie);
        Movie Delete(Movie movie);
    }
}
