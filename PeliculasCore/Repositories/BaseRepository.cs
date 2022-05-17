using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PeliculasCore.DataAccess;
using PeliculasCore.DTOs;
using PeliculasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityId
    {
        private readonly ApplicationDbContext db;
        public BaseRepository(ApplicationDbContext db)
        {
            this.db = db;
        }        

        public virtual void Update(T entity) => UpdateRange(new List<T> { entity });


        public virtual void UpdateRange(IEnumerable<T> entities)
        {            
            db.Set<T>().UpdateRange(entities);
            db.SaveChanges();
        }

        public virtual IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            db.Set<T>().AddRange(entities);
            db.SaveChanges();
            
            return entities;
        }

        public virtual T Add(T entity) => AddRange(new List<T> { entity }).Single();

        public virtual void RemoveRange(IEnumerable<T> entities)
        {            
            foreach (var entity in entities)
            {
                db.Entry(entity).State = EntityState.Deleted;
            }            
            db.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Any(predicate);
        }

        public virtual void Remove(T entity) => RemoveRange(new List<T> { entity });

        public virtual T? FindOrDefault(int id) => db.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);

        public virtual async Task<T?> FindOrDefaultAsync(int id) => await db.Set<T>().FindAsync(id);

        public virtual List<T> List() => db.Set<T>().AsNoTracking().ToList();

        public virtual List<T> List(PaginationDto pagination)
        {
            var skip = (pagination.Page - 1) * pagination.RowsPerPage;
            return db.Set<T>().AsNoTracking().Skip(skip).Take(pagination.RowsPerPage).ToList();
        }

        public async virtual Task<List<T>> ListAsync(PaginationDto pagination)
        {
            var skip = (pagination.Page - 1) * pagination.RowsPerPage;
            return await db.Set<T>().AsNoTracking().Skip(skip).Take(pagination.RowsPerPage).ToListAsync();
        }


        public virtual Task<List<T>> ListAsync() => db.Set<T>().AsNoTracking().ToListAsync();

        public virtual int Count() => db.Set<T>().Count();

    }
}
