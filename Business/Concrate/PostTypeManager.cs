using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class PostTypeManager : IPostTypeService
    {
        private readonly IPostTypeDal _postTypeDal;

        public PostTypeManager(IPostTypeDal postTypeDal)
        {
            _postTypeDal = postTypeDal;
        }

        public PostType Get(int? id)
        {
            return _postTypeDal.Get(pt=>pt.PostTypeId==id);
        }

        public IList<PostType> GetAll()
        {
            return _postTypeDal.GetAll();
        }

        public void Add(PostType post)
        {
            _postTypeDal.Add(post);
            
        }

        public void Update(PostType post)
        {
            _postTypeDal.Update(post);
        }

        public void Delete(PostType post)
        {
            _postTypeDal.Delete(post);
        }
    }
}
