using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class ProductionPerformerManager : IProductionPerformerService
    {
        private readonly IProductionPerformerDal _productionPerformerDal;

        public ProductionPerformerManager(IProductionPerformerDal productionPerformerDal)
        {
            _productionPerformerDal = productionPerformerDal;
        }

        public ProductionPerformer GetProductionByPerformer(int? id)
        {
            return _productionPerformerDal.Get(p => p.PerformerId == id);
        }

        public ProductionPerformer GetPerformerByProduction(int? id)
        {
            return _productionPerformerDal.Get(p=>p.ProductionId==id);
        }

        public IList<ProductionPerformer> GetAllProductionsByPerformer(int? id)
        {
            return _productionPerformerDal.GetAll(p => p.PerformerId == id);
        }

        public IList<ProductionPerformer> GetAllPerformersByProduction(int? id)
        {
            return _productionPerformerDal.GetAll(p => p.ProductionId == id);
        }

        public void Add(ProductionPerformer productionPerformer)
        {
            _productionPerformerDal.Add(productionPerformer);
        }

        public void Update(ProductionPerformer productionPerformer)
        {
            _productionPerformerDal.Update(productionPerformer);
        }

        public void Delete(ProductionPerformer productionPerformer)
        {
            _productionPerformerDal.Delete(productionPerformer);
        }
    }
}
