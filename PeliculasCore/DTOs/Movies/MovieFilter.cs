using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PeliculasCore.Helpers;
using PeliculasCore.Models;

namespace PeliculasCore.DTOs.Movies
{
    public class MovieFilter
    {
        
        public int Page { get; set; } = 1;
        public int RowsPerPage { get; set; } = 10;

        public PaginationDto Pagination 
        {
            get { return new PaginationDto {  Page= Page, RowsPerPage = RowsPerPage }; }
        }

        public string? Title { get; set; }

        public bool? OnScreen { get; set; }

        public int GeneroId { get; set; }

        public bool? ComingSoon { get; set; }

        public Expression<Func<Movie, bool>> GetPredicate()
        {
            Expression<Func<Movie, bool>> predicate = PredicateBuilder.True<Movie>();            
            if(this.Title != null)
            {
                predicate = predicate.And<Movie>(x => x.Title.Contains(Title, StringComparison.OrdinalIgnoreCase));
            }
            if(this.OnScreen != null)
            {
                predicate = predicate.And<Movie>(x => x.OnScreen);
            }
            if(GeneroId != 0)
            {
                predicate = predicate.And<Movie>(x => x.MovieGeneroAssocs.Select(y => y.GeneroId).Contains(GeneroId));               
            }
            if(ComingSoon != null)
            {
                predicate = predicate.And<Movie>(x => x.ReleaseDate > DateTime.Now);
            }
            return predicate;

        }
    }
}
