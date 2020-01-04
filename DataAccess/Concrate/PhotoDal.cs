using System.Linq;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrate
{
    public class PhotoDal : Repository<Photo,FantastikContext>,IPhotoDal{
        public bool Publish(int? id)
        {
            using var context = new FantastikContext();
            var photo = context.Photos.FirstOrDefault(c => c.PhotoId == id);
            if (photo != null)
            {
                photo.StatusId = (int)Statuses.Active;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Draft(int? id)
        {
            using var context = new FantastikContext();
            var photo = context.Photos.FirstOrDefault(c => c.PhotoId == id);
            if (photo != null)
            {
                photo.StatusId = (int)Statuses.Passive;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(int? id)
        {
            using var context = new FantastikContext();
            var photo = context.Photos.FirstOrDefault(c => c.PhotoId == id);
            if (photo != null)
            {
                photo.StatusId = (int)Statuses.Deleted;
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
