using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class PhotoManager : IPhotoService
    {
        private readonly IPhotoDal _photoDal;

        public PhotoManager(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }

        public Photo GetWeb(string slug)
        {
            return _photoDal.Get(p => p.Slug == slug && p.StatusId == (int) Statuses.Active);
        }

        public Photo GetAdmin(int id)
        {
            return _photoDal.Get(p => p.PhotoId == id && p.StatusId != (int)Statuses.Deleted);
        }

        public IList<Photo> GetAllWeb()
        {
            return _photoDal.GetAll(p=>p.StatusId == (int)Statuses.Active);
        }

        public IList<Photo> GetAllAdmin()
        {
            return _photoDal.GetAll(p => p.StatusId != (int)Statuses.Deleted);
        }

        public void Add(Photo photo)
        {
            _photoDal.Add(photo);
        }

        public void Update(Photo photo)
        {
            _photoDal.Update(photo);
        }

        public void Delete(Photo photo)
        {
            _photoDal.Delete(photo);
        }

        public bool Publish(int id)
        {
            return _photoDal.Publish(id);
        }

        public bool Draft(int id)
        {
            return _photoDal.Draft(id);
        }

        public bool Remove(int id)
        {
            return _photoDal.Remove(id);
        }
    }
}
