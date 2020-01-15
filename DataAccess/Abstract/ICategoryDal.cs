using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        IList<Category> GetAllByProductionId(int? productionId);
        IList<Category> GetAllByPostId(int? postId);
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
    }
}
