using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrate
{
    public class ProductionCategoryManager : IProductionCategoryService
    {
        private readonly IProductionCategoryDal _categoryDal;

        public ProductionCategoryManager(IProductionCategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public ProductionCategory GetCategoryByProductionId(int? id)
        {
            return _categoryDal.Get(pc => pc.ProductionId == id);
        }

        public ProductionCategory GetProductionByCategoryId(int? id)
        {
            return _categoryDal.Get(pc => pc.CategoryId == id);
        }

        public IList<ProductionCategory> GetAllByCategoryId(int? id)
        {
            return _categoryDal.GetAll(pc => pc.CategoryId == id);
        }

        public IList<ProductionCategory> GetAllByProductionId(int? id)
        {
            return _categoryDal.GetAll(pc => pc.ProductionId == id);
        }

        public void Add(ProductionCategory productionCategory)
        {
            _categoryDal.Add(productionCategory);
        }

        public void Update(ProductionCategory productionCategory)
        {
            _categoryDal.Update(productionCategory);
        }

        public void Delete(ProductionCategory productionCategory)
        {
            _categoryDal.Delete(productionCategory);
        }
    }
}
