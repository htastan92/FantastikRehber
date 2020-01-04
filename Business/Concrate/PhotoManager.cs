using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<Photo> GetWeb(string slug)
        {
            return new SuccessDataResult<Photo>(_photoDal.Get(p => p.Slug == slug && p.StatusId == (int)Statuses.Active));
        }

        public IDataResult<Photo> GetAdmin(int id)
        {
            return new SuccessDataResult<Photo>(_photoDal.Get(p => p.PhotoId == id && p.StatusId != (int)Statuses.Deleted));
        }

        public IDataResult<IList<Photo>> GetAllWeb()
        {
            return new SuccessDataResult<IList<Photo>>(_photoDal.GetAll(p => p.StatusId == (int) Statuses.Active));
        }

        public IDataResult<IList<Photo>> GetAllAdmin()
        {
            return new SuccessDataResult<IList<Photo>>(_photoDal.GetAll(p => p.StatusId != (int)Statuses.Deleted));
        }

        public IResult Add(Photo photo)
        {
            _photoDal.Add(photo);
            return new SuccessResult(Messages.PhotoAdded);
        }

        public IResult Update(Photo photo)
        {
            _photoDal.Update(photo);
            return new SuccessResult(Messages.PhotoUpdated);
        }

        public IResult Delete(Photo photo)
        {
            _photoDal.Delete(photo);
            return new SuccessResult(Messages.PhotoDeleted);
        }

        public IResult Publish(int? id)
        {
            _photoDal.Publish(id);
            return new SuccessResult(Messages.PhotoPublished);
        }

        public IResult Draft(int? id)
        {
           _photoDal.Draft(id);
           return new SuccessResult(Messages.PhotoDrafted);
        }

        public IResult Remove(int? id)
        {
             _photoDal.Remove(id);
            return new SuccessResult(Messages.PhotoRemoved);
        }
    }
}
