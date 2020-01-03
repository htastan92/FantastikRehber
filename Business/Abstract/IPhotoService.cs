using System.Collections.Generic;
using Entities;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        Photo GetWeb(string slug);
        Photo GetAdmin(int id);
        IList<Photo> GetAllWeb();
        IList<Photo> GetAllAdmin();
        void Add(Photo photo);
        void Update(Photo photo);
        void Delete(Photo photo);
        bool Publish(int id);
        bool Draft(int id);
        bool Remove(int id);
    }
}
