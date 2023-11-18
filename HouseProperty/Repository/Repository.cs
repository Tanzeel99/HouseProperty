using AutoMapper;
using HouseProperty.Data;
using HouseProperty.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HouseProperty.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly dbContext db;
        internal DbSet<T> dbSet;
        public Repository(dbContext _db)
        {
            db = _db;
            this.dbSet = db.Set<T>();
        }


        public async Task Create(T entity)
        {
            await db.AddAsync(entity);
            await Save();
        }

        public async Task Delete(T entity)
        {
            db.Remove(entity);
            await Save();
        }

        public async Task<List<T>> GetAllProperty(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task<T> GetProperty(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);


            return await query.FirstOrDefaultAsync();
        }

        public async Task Update(T entity)
        {
            db.Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
