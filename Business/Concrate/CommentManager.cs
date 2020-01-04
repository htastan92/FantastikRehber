using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IDataResult<Comment> GetWeb(string slug)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.Slug == slug && c.StatusId == (int)Statuses.Active));
        }

        public IDataResult<Comment> GetAdmin(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.CommentId == id && c.StatusId != (int)Statuses.Deleted));
        }

        public IDataResult<IList<Comment>> GetAllWeb()
        {
            return new SuccessDataResult<IList<Comment>>(_commentDal.GetAll(c => c.StatusId == (int) Statuses.Active));
        }

        public IDataResult<IList<Comment>> GetAllAdmin()
        {
            return new SuccessDataResult<IList<Comment>>(_commentDal.GetAll(c => c.StatusId != (int)Statuses.Deleted));
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }

        public IResult Publish(int id)
        { 
            _commentDal.Publish(id);
            return new SuccessResult(Messages.CommentPublished);
        }

        public IResult Draft(int id)
        {
            _commentDal.Draft(id);
            return new SuccessResult(Messages.CommentDrafted);
        }

        public IResult Remove(int id)
        {
            _commentDal.Remove(id);
            return new SuccessResult(Messages.CommentRemoved);
        }
    }
}
