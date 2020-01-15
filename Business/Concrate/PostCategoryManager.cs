using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class PostCategoryManager : IPostCategoryService
    {
        private readonly IPostCategoryDal _postCategoryDal;

        public PostCategoryManager(IPostCategoryDal postCategoryDal)
        {
            _postCategoryDal = postCategoryDal;
        }


        public PostCategory GetByPostId(int? id)
        {
           return _postCategoryDal.Get(p=>p.PostId==id);
        }

        public PostCategory GetByCategoryId(int? id)
        {
            return _postCategoryDal.Get(p => p.CategoryId == id);
        }

        public IList<PostCategory> GetAll()
        {
            return _postCategoryDal.GetAll();
        }

        public IList<PostCategory> GetAllByCategoryId(int? id)
        {
            return _postCategoryDal.GetAll(p => p.CategoryId == id);
        }

        public IList<PostCategory> GetAllByPostId(int? id)
        {
            return _postCategoryDal.GetAll(p=>p.PostId==id);
        }

        public void Add(PostCategory postCategory)
        {
            _postCategoryDal.Add(postCategory);
        }

        public void Update(PostCategory postCategory)
        {
           _postCategoryDal.Update(postCategory);
        }

        public void Delete(PostCategory postCategory)
        { 
            _postCategoryDal.Delete(postCategory);
        }
    }
}
