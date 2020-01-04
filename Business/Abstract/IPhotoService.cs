using System.Collections.Generic;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        IDataResult<Photo> GetWeb(string slug);
        IDataResult<Photo> GetAdmin(int id);
        IDataResult<IList<Photo>> GetAllWeb();
        IDataResult<IList<Photo>> GetAllAdmin();
        IResult Add(Photo photo);
        IResult Update(Photo photo);
        IResult Delete(Photo photo);
        IResult Publish(int id);
        IResult Draft(int id);
        IResult Remove(int id);
    }
}
