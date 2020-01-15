using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Business.Abstract
{
    public interface IPostCategoryService
    {
        PostCategory GetByPostId(int? id);
        PostCategory GetByCategoryId(int? id);
        IList<PostCategory> GetAll();
        IList<PostCategory> GetAllByCategoryId(int? id);
        IList<PostCategory> GetAllByPostId(int? id);
        void Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        void Delete(PostCategory postCategory);
    }
}
