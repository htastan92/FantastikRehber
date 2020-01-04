using Core.DataAccess.Abstract;
using Entities;

namespace DataAccess.Abstract
{
    public interface IPostDal : IRepository<Post>
    {
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
    }
}
