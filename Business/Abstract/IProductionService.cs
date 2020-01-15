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
        IDataResult<Production> GetProductionByCategoryWeb(string slug,int? categoryId);
        IDataResult<Production> GetProductionByPerformerWeb(string slug, int? performerId);
        IDataResult<Production> GetProductionByCategoryAdmin(string slug, int? categoryId);
        IDataResult<Production> GetProductionByPerformerAdmin(string slug, int? performerId);
        IDataResult<Production> GetAdmin(int? id);
        IDataResult<IList<Production>> GetAllAdmin();
        IDataResult<IList<Production>> GetAllWeb();
        IDataResult<IList<Production>> GetAllProductionsByCategoryWeb(int? categoryId);
        IDataResult<IList<Production>> GetAllProductionsByPerformerWeb(int? performerId);
        IDataResult<IList<Production>> GetAllProductionsByCategoryAdmin(int? categoryId);
        IDataResult<IList<Production>> GetAllProductionsByPerformerAdmin(int? performerId);
        IResult Add(Production production);
        IResult Update(Production production);
        IResult Publish(int? id);
        IResult Draft(int? id);
        IResult Remove(int? id);
    }
}
