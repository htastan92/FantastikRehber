using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.Concrate;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate
{
    public class PerformerDal : Repository<Performer,FantastikContext>,IPerformerDal
    {
        public IList<Performer> GetAllByProductionId(int? productionId)
        {
            using var context = new FantastikContext();
            var production = context.Productions.Include(p => p.ProductionPerformers).ThenInclude(pc => pc.Performer)
                .FirstOrDefault(p => p.ProductionId == productionId);
            if (production!=null)
            {
                var performers = production.ProductionPerformers.Select(p => p.Performer).ToList();
                return performers;
            }
            else
            {
                throw new Exception("Bu ProductionId ile eşleşen bir Performer bulunamadı...");
            }
        }
    }
}
