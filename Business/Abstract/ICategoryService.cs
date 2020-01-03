using System.Collections.Generic;
using Entities;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Category GetWeb(string slug);
        Category GetAdmin(int id);
        IList<Category> GetAllWeb();
        IList<Category> GetAllAdmin();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        bool Publish(int id);
        bool Draft(int id);
        bool Remove(int id);

    }
}
