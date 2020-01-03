using System.Linq;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrate
{
    public class CommentDal : Repository<Comment,FantastikContext>,ICommentDal{
        public bool Publish(int id)
        {
            using var context = new FantastikContext();
            var comment = context.Comments.FirstOrDefault(c => c.CommentId == id);
            if (comment != null)
            {
                comment.StatusId = (int)Statuses.Active;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Draft(int id)
        {
            using var context = new FantastikContext();
            var comment = context.Comments.FirstOrDefault(c => c.CommentId == id);
            if (comment != null)
            {
                comment.StatusId = (int)Statuses.Passive;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            using var context = new FantastikContext();
            var comment = context.Comments.FirstOrDefault(c => c.CommentId == id);
            if (comment != null)
            {
                comment.StatusId = (int)Statuses.Deleted;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
