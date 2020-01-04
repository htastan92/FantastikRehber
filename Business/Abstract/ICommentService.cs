using System.Collections.Generic;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<Comment> GetWeb(string slug);
        IDataResult<Comment> GetAdmin(int id);
        IDataResult<IList<Comment>> GetAllWeb();
        IDataResult<IList<Comment>> GetAllAdmin();
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Publish(int? id);
        IResult Draft(int? id);
        IResult Remove(int? id);
    }
}
