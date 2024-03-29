﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Entities;


namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetWeb(string slug);
        IDataResult<Category> GetAdmin(int? id);
        IDataResult<IList<Category>> GetAllWeb();
        IDataResult<IList<Category>> GetAllAdmin();
        IDataResult<IList<Category>> GetAllByPostId(int? categoryId);
        IDataResult<IList<Category>> GetAllByProductionId(int? productionId);
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Publish(int? id);
        IResult Draft(int? id);
        IResult Remove(int? id);

    }
}
