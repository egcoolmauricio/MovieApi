using Microsoft.EntityFrameworkCore;
using PeliculasCore.DataAccess;
using PeliculasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Repositories
{
    public class MovieRepository : BaseRepository<Movie>
    {
        private readonly ApplicationDbContext dbContext;

        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override Movie? FindOrDefault(int id)
        {
            return dbContext.Movies
                .Include(x => x.MovieGeneroAssocs)
                .Include(x => x.MovieActorAssocs)
                .FirstOrDefault(x => x.Id == id);
        }

    }
}
