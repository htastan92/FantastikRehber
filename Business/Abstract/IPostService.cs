using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<Post> GetWeb(string slug);
        IDataResult<Post> GetAdmin(int id);
        IDataResult<IList<Post>> GetAllWeb();
        IDataResult<IList<Post>> GetAllAdmin();
        IResult Add(Post post);
        IResult Update(Post post);
        IResult Publish(int id);
        IResult Draft(int id);
        IResult Remove(int id);
    }
}
