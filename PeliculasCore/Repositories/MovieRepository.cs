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
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
