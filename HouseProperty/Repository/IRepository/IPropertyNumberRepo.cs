using HouseProperty.Model;
using System.Linq.Expressions;

namespace HouseProperty.Repository.IRepository
{
    public interface IPropertyNumberRepo : IRepository<PropertyNumber>
    {
        Task<PropertyNumber> Update(PropertyNumber entity);
    }
}
