using HouseProperty.Model;
using System.Linq.Expressions;

namespace HouseProperty.Repository.IRepository
{
    public interface IPropertyRepo : IRepository<Property>
    {
        Task<Property> Update(Property entity);
    }
}
