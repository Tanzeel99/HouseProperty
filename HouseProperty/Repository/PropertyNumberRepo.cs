using AutoMapper;
using HouseProperty.Data;
using HouseProperty.Model;
using HouseProperty.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace HouseProperty.Repository
{
    public class PropertyNumberRepo : Repository<PropertyNumber>, IPropertyNumberRepo
    {
        private readonly dbContext db;
        public PropertyNumberRepo(dbContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<PropertyNumber> Update(PropertyNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            db.PropertyNumbers.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
