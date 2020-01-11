using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface IProductionTypeService
    {
        ProductionType Get(int? id);
        IList<ProductionType> GetAll();
        void Add(ProductionType post);
        void Update(ProductionType post);
        void Delete(ProductionType post);
    }
}
