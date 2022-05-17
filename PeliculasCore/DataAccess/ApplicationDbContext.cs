using Microsoft.EntityFrameworkCore;
using PeliculasCore.Models;

namespace PeliculasCore.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActorAssoc>()
                .HasKey(x => new { x.MovieId, x.ActorId });

            modelBuilder.Entity<MovieGeneroAssoc>()
                .HasKey(x => new { x.MovieId, x.GeneroId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActorAssoc> MovieActorAssoc { get; set; }
        public DbSet<MovieGeneroAssoc> MovieGeneroAssoc{ get; set; }
    }
}
