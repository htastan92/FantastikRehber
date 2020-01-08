using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<Category> GetWeb(string slug)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Slug == slug && c.StatusId == (int)Statuses.Active));
        }

        public IDataResult<Category> GetAdmin(int? id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == id && c.StatusId != (int)Statuses.Deleted));
        }

        public IDataResult<IList<Category>> GetAllWeb()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll(c => c.StatusId == (int)Statuses.Active));
        }

        public IDataResult<IList<Category>> GetAllAdmin()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll(c => c.StatusId != (int)Statuses.Deleted));
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IResult Publish(int? id)
        {
            _categoryDal.Publish(id);
            return new SuccessResult(Messages.CategoryPublished);
        }

        public IResult Draft(int? id)
        {
            _categoryDal.Draft(id);
            return new SuccessResult(Messages.CategoryDrafted);
        }

        public IResult Remove(int? id)
        {
            _categoryDal.Remove(id);
            return new SuccessResult(Messages.CategoryRemoved);
        }
    }
}
