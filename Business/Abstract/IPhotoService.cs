using System.Collections.Generic;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        IDataResult<Photo> GetWeb(string slug);
        IDataResult<Photo> GetAdmin(int? postId);
        IDataResult<Photo> GetPhotoByPostAdmin(int? postId);
        IDataResult<Photo> GetPhotoByPostWeb(int? postId);
        IDataResult<IList<Photo>> GetAllWeb();
        IDataResult<IList<Photo>> GetAllAdmin();
        IDataResult<IList<Photo>> GetPhotoByAllAdmin(int? postId);
        IDataResult<IList<Photo>> GetPhotoByAllWeb(int? postId);
        IResult Add(Photo photo);
        IResult Update(Photo photo);
        IResult Delete(Photo photo);
        IResult Publish(int? id);
        IResult Draft(int? id);
        IResult Remove(int? id);
        IDataResult<Photo> Find(string imageUrl);
    }
}
