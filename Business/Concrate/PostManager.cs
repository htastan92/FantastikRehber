using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public IDataResult<Post> GetWeb(string slug)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.Slug == slug && p.StatusId == (int) Statuses.Active));
        }

        public IDataResult<Post> GetAdmin(int id)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.PostId == id && p.StatusId != (int)Statuses.Deleted));
        }

        public IDataResult<IList<Post>> GetAllWeb()
        {
            return new SuccessDataResult<IList<Post>>(_postDal.GetAll(p => p.StatusId == (int) Statuses.Active));
        }

        public IDataResult<IList<Post>> GetAllAdmin()
        {
            return new SuccessDataResult<IList<Post>>(_postDal.GetAll(p => p.StatusId != (int)Statuses.Deleted));
        }

        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult(Messages.PostAdded);
        }

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdated);
        }
        
        public IResult Publish(int id)
        {
             _postDal.Publish(id);
             return new SuccessResult(Messages.PostPublished);
        }

        public IResult Draft(int id)
        {
            _postDal.Draft(id);
            return new SuccessResult(Messages.PostDrafted);
        }

        public IResult Remove(int id)
        {
            _postDal.Remove(id);
            return new SuccessResult(Messages.PostRemoved);
        }
    }
}
