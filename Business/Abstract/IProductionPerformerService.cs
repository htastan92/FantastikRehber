using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Business.Abstract
{
    public interface IProductionPerformerService
    {
        ProductionPerformer GetProductionByPerformer(int? id);
        ProductionPerformer GetPerformerByProduction(int? id);
        IList<ProductionPerformer> GetAllProductionsByPerformer(int? id);
        IList<ProductionPerformer> GetAllPerformersByProduction(int? id);
        void Add(ProductionPerformer productionPerformer);
        void Update(ProductionPerformer productionPerformer);
        void Delete(ProductionPerformer productionPerformer);
    }
}
