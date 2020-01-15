using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.Abstract;
using Entities;

namespace DataAccess.Abstract
{
    public interface IPerformerDal : IRepository<Performer>
    {
        IList<Performer> GetAllByProductionId(int? productionId);
    }
}
