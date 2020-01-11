using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{ 
    public interface IProductionService
    {
        IDataResult<Production> GetWeb(string slug);
        IDataResult<Production> GetAdmin(int? id);
        IDataResult<IList<Production>> GetAllWeb();
        IDataResult<IList<Production>> GetAllAdmin();
        IResult Add(Production production);
        IResult Update(Production production);
        IResult Publish(int? id);
        IResult Draft(int? id);
        IResult Remove(int? id);
    }
}
