using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface IPerformerService
    {
        IDataResult<Performer> Get(int? id);
        IDataResult<IList<Performer>> GetAll();
        IDataResult<IList<Performer>> GetAllByProductionId(int? productionId);
        IResult Add(Performer performer);
        IResult Update(Performer performer);
        IResult Delete(Performer performer);
    }
}
