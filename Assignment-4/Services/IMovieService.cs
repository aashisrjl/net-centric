using System.Collections.Generic;
using Assignment_4.Models;

namespace Assignment_4.Services
{
    public interface IMovieService
    {
        List<Movies> GetAllMovies();
        void AddMovie(Movies movie);
        Movies? GetMovieById(int id);
        void UpdateMovie(Movies movie);
        void DeleteMovie(int id);
    }
}