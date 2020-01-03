using System.Collections.Generic;
using Entities;

namespace Business.Abstract
{
    public interface ICommentService
    {
        Comment GetWeb(string slug);
        Comment GetAdmin(int id);
        IList<Comment> GetAllWeb();
        IList<Comment> GetAllAdmin();
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
        bool Publish(int id);
        bool Draft(int id);
        bool Remove(int id);
    }
}
