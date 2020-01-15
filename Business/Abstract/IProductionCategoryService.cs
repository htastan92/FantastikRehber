using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Business.Abstract
{
    public interface IProductionCategoryService
    {
        ProductionCategory GetCategoryByProductionId(int? id);
        ProductionCategory GetProductionByCategoryId(int? id);
        IList<ProductionCategory> GetAllByCategoryId(int? id);
        IList<ProductionCategory> GetAllByProductionId(int? id);
        void Add(ProductionCategory productionCategory);
        void Update(ProductionCategory productionCategory);
        void Delete(ProductionCategory productionCategory);
    }
}
