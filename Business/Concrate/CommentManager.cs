using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public Comment GetWeb(string slug)
        {
            return _commentDal.Get(c => c.Slug == slug && c.StatusId == (int)Statuses.Active);
        }

        public Comment GetAdmin(int id)
        {
            return _commentDal.Get(c => c.CommentId == id && c.StatusId != (int)Statuses.Deleted);
        }

        public IList<Comment> GetAllWeb()
        {
            return _commentDal.GetAll(c => c.StatusId == (int) Statuses.Active);
        }

        public IList<Comment> GetAllAdmin()
        {
            return _commentDal.GetAll(c => c.StatusId != (int)Statuses.Deleted);
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public void Delete(Comment comment)
        {
           _commentDal.Delete(comment);
        }

        public bool Publish(int id)
        {
            return _commentDal.Publish(id);
        }

        public bool Draft(int id)
        {
            return _commentDal.Draft(id);
        }

        public bool Remove(int id)
        {
            return _commentDal.Remove(id);
        }
    }
}
