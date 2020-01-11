using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;

namespace DataAccess.Concrate
{
    public class ProductionDal : Repository<Production,FantastikContext>,IProductionDal
    {
        public void Publish(int? id)
        {
            FantastikContext context = new FantastikContext();
            var production = context.Productions.FirstOrDefault(p => p.ProductionId == id);
            if (production != null)
            {
                production.StatusId = (int)Statuses.Active;
                context.SaveChanges();
            }
        }

        public void Draft(int? id)
        {
            FantastikContext context = new FantastikContext();
            var production = context.Productions.FirstOrDefault(p => p.ProductionId == id);
            if (production != null)
            {
                production.StatusId = (int)Statuses.Passive;
                context.SaveChanges();
            }
        }

        public void Remove(int? id)
        {
            FantastikContext context = new FantastikContext();
            var production = context.Productions.FirstOrDefault(p => p.ProductionId == id);
            if (production != null)
            {
                production.StatusId = (int)Statuses.Deleted;
                context.SaveChanges();
            }
        }
    }
}
