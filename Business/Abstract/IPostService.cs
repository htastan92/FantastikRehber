using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Business.Abstract
{
    public interface IPostService
    {
        Post GetWeb(string slug);
        Post GetAdmin(int id);
        IList<Post> GetAllWeb();
        IList<Post> GetAllAdmin();
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
        bool Publish(int id);
        bool Draft(int id);
        bool Remove(int id);
    }
}
