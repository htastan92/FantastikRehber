using Core.DataAccess.Abstract;
using Entities;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        bool Publish(int id);
        bool Draft(int id);
        bool Remove(int id);
    }
}
