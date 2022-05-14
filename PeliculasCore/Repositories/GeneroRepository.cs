using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PeliculasCore.DataAccess;
using PeliculasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Repositories
{
    public class GeneroRepository : BaseRepository<Genero>
    {
        public GeneroRepository(ApplicationDbContext db) : base(db)
        {
        }


    }
}
