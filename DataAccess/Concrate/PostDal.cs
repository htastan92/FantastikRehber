using System.Linq;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrate
{
    public class PostDal:Repository<Post,FantastikContext>,IPostDal{
        public bool Publish(int id)
        {
            using var context = new FantastikContext();
            var post = context.Posts.FirstOrDefault(c => c.PostId == id);
            if (post != null)
            {
                post.StatusId = (int)Statuses.Active;
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
            var post = context.Posts.FirstOrDefault(c => c.PostId == id);
            if (post != null)
            {
                post.StatusId = (int)Statuses.Passive;
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
            var post = context.Posts.FirstOrDefault(c => c.PostId == id);
            if (post != null)
            {
                post.StatusId = (int)Statuses.Deleted;
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
