using Core.DataAccess.Abstract;
using Entities;

namespace DataAccess.Abstract
{
    public interface IPhotoDal : IRepository<Photo>
    {
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
        Photo Find(string imageUrl);
    }
}
