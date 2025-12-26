using Assignment_4.Models;
using Microsoft.EntityFrameworkCore;
using Assignment_4.Data;

namespace Assignment_4.Services
{
    public class MovieService: IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public List<Movies> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movies? GetMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void AddMovie(Movies movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movies movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
