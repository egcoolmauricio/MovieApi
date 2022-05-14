using Microsoft.EntityFrameworkCore;
using PeliculasCore.Models;

namespace PeliculasCore.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}
