using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities;

namespace DataAccess.Abstract
{
    public interface IPostDal : IRepository<Post>
    {
        Post GetPostByCategoryWeb(string slug,int? categoryId);
        Post GetPostByCategoryAdmin(string slug, int? categoryId);
        IList<Post> GetAllPostsByCategoryWeb(int? categoryId);
        IList<Post> GetAllPostsByCategoryAdmin(int? categoryId);
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
    }
}
