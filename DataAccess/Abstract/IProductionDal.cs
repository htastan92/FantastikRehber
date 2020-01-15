using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Abstract;
using Core.DataAccess.Concrate;
using DataAccess.Context;
using Entities;

namespace DataAccess.Abstract
{
    public interface IProductionDal : IRepository<Production>
    {
        Production GetProductionByCategoryWeb(string slug,int? categoryId);
        Production GetProductionByPerformerWeb(string slug,int? performerId);
        Production GetProductionByCategoryAdmin(string slug,int? categoryId);
        Production GetProductionByPerformerAdmin(string slug,int? performerId);
        IList<Production> GetAllProductionsByCategoryWeb(int? categoryId);
        IList<Production> GetAllProductionsByPerformerWeb(int? performerId);
        IList<Production> GetAllProductionsByCategoryAdmin(int? categoryId);
        IList<Production> GetAllProductionsByPerformerAdmin(int? performerId);
        void Publish(int? id);
        void Draft(int? id);
        void Remove(int? id);
    }
}
