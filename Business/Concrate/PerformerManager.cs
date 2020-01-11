using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class PerformerManager : IPerformerService
    {
        private readonly IPerformerDal _performerDal;

        public PerformerManager(IPerformerDal performerDal)
        {
            _performerDal = performerDal;
        }


        public IDataResult<Performer> Get(int? id)
        {
             return new SuccessDataResult<Performer>(_performerDal.Get(p=>p.PerformerId==id));
        }

        public IDataResult<IList<Performer>> GetAll()
        {
            return new SuccessDataResult<IList<Performer>>(_performerDal.GetAll());
        }

        public IResult Add(Performer performer)
        {
            _performerDal.Add(performer);
            return new SuccessResult();
        }

        public IResult Update(Performer performer)
        {

            _performerDal.Update(performer);
            return new SuccessResult();
        }

        public IResult Delete(Performer performer)
        {
            _performerDal.Delete(performer);
            return new SuccessResult();
        }
    }
}
