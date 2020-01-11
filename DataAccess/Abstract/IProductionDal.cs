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
        void Publish(int? id);
        void Draft(int? id);
        void Remove(int? id);
    }
}
