using System.Collections.Generic;
using Business.Abstract;
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

        public Post GetWeb(string slug)
        {
            return _postDal.Get(p => p.Slug == slug && p.StatusId == (int) Statuses.Active);
        }

        public Post GetAdmin(int id)
        {
            return _postDal.Get(p => p.PostId == id && p.StatusId != (int)Statuses.Deleted);
        }

        public IList<Post> GetAllWeb()
        {
            return _postDal.GetAll(p => p.StatusId == (int) Statuses.Active);
        }

        public IList<Post> GetAllAdmin()
        {
            return _postDal.GetAll(p => p.StatusId != (int)Statuses.Deleted);
        }

        public void Add(Post post)
        {
            _postDal.Add(post);
        }

        public void Update(Post post)
        {
            _postDal.Update(post);
        }

        public void Delete(Post post)
        {
            _postDal.Delete(post);
        }

        public bool Publish(int id)
        {
            return _postDal.Publish(id);
        }

        public bool Draft(int id)
        {
            return _postDal.Draft(id);
        }

        public bool Remove(int id)
        {
            return _postDal.Remove(id);
        }
    }
}
