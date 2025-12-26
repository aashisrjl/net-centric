using Microsoft.EntityFrameworkCore;
using Assignment_4.Models; 

namespace Assignment_4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Actor> Actor { get; set; }
        
        public DbSet<Character> Character { get; set; }
    }


}
