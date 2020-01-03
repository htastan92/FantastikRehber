using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetWeb(string slug)
        {
            return _categoryDal.Get(c => c.Slug == slug && c.StatusId == (int) Statuses.Active);
        }

        public Category GetAdmin(int id)
        {
            return _categoryDal.Get(c => c.CategoryId == id && c.StatusId != (int)Statuses.Deleted);
        }

        public IList<Category> GetAllWeb()
        {
            return _categoryDal.GetAll(c => c.StatusId == (int) Statuses.Active);
        }

        public IList<Category> GetAllAdmin()
        {
            return _categoryDal.GetAll(c => c.StatusId != (int)Statuses.Deleted);
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public bool Publish(int id)
        {
            return _categoryDal.Publish(id);
        }

        public bool Draft(int id)
        {
            return _categoryDal.Draft(id);
        }

        public bool Remove(int id)
        {
            return _categoryDal.Remove(id);
        }
    }
}
