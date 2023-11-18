using AutoMapper;
using HouseProperty.Data;
using HouseProperty.Model;
using HouseProperty.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace HouseProperty.Repository
{
    public class PropertyRepo : Repository<Property>, IPropertyRepo
    {
        private readonly dbContext db;
        public PropertyRepo(dbContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<Property> Update(Property entity)
        {
            entity.UpdatedDate = DateTime.Now;
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
