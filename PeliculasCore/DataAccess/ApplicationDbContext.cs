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
        public DbSet<MovieGeneroAssoc> MovieGeneroAssoc { get; set; }

        //private void SeedData(ModelBuilder modelBuilder) 
        //{ 
        //    var aventura = new Genero() { Id = 4, Name = "Aventura" };
        //    var animation = new Genero() { Id = 5, Name = "Animación" };
        //    var suspenso = new Genero() {Id = 6, Name = "Suspenso" };
        //    var romance = new Genero() { Id = 7, Name = "Romance" };
        //    modelBuilder.Entity<Genero>()
        //}
    }
}
