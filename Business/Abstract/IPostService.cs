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
        IDataResult<Post> GetWebByCategory(string slug,int? categoryId);
        IDataResult<Post> GetAdmin(int? id);
        IDataResult<Post> GetAdminByCategory(string slug ,int? categoryId);
        IDataResult<IList<Post>> GetAllWeb();
        IDataResult<IList<Post>> GetAllWebByCategory(int? categoryId);
        IDataResult<IList<Post>> GetAllAdmin();
        IDataResult<IList<Post>> GetAllAdminByCategory(int? categoryId);
        IResult Add(Post post);
        IResult Update(Post post);
        IResult Publish(int? id);
        IResult Draft(int? id);
        IResult Remove(int? id);
    }
}
