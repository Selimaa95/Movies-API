using MoviesAPI.Models;

namespace Movies.BL.Services.Genres;

public interface IGenresService
{
    Task<IEnumerable<Genre>> GetAllAsync();
    Task<Genre> GetByIdAsync(byte id);
    Task<Genre> CreateAsync(Genre genre);
    Genre Update(Genre genre);
    Genre Delete(Genre genre);
    Task<bool> IsValidGenre(byte id);


}
