using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface IPostTypeService
    {
        PostType Get(int? id);
        IList<PostType> GetAll();
        void Add(PostType post);
        void Update(PostType post);
        void Delete(PostType post);
    }
}
