using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class ProductionManager : IProductionService
    {
        private readonly IProductionDal _productionDal;

        public ProductionManager(IProductionDal productionDal)
        {
            _productionDal = productionDal;
        }

        public IDataResult<Production> GetWeb(string slug)
        {
            return new SuccessDataResult<Production>(_productionDal.Get(p=>p.Slug==slug&&p.StatusId==(int)Statuses.Active));
        }

        public IDataResult<Production> GetAdmin(int? id)
        {
            return new SuccessDataResult<Production>(_productionDal.Get(p => p.ProductionId == id && p.StatusId != (int)Statuses.Active));
        }

        public IDataResult<IList<Production>> GetAllWeb()
        {
            return new SuccessDataResult<IList<Production>>(_productionDal.GetAll(p=>p.StatusId==(int)Statuses.Active));
        }

        public IDataResult<IList<Production>> GetAllAdmin()
        {
            return new SuccessDataResult<IList<Production>>(_productionDal.GetAll(p => p.StatusId != (int)Statuses.Deleted));
        }

        public IResult Add(Production production)
        {
            _productionDal.Add(production);
            return new SuccessResult();
        }

        public IResult Update(Production production)
        {
            _productionDal.Update(production);
            return new SuccessResult();
        }

        public IResult Publish(int? id)
        {
             _productionDal.Publish(id);
            return new SuccessResult();
        }

        public IResult Draft(int? id)
        {
            _productionDal.Draft(id);
            return new SuccessResult();
        }

        public IResult Remove(int? id)
        {
            _productionDal.Remove(id);
            return new SuccessResult();
        }
    }
}
