using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.ProductionTypeViewModels
{
    public class ProductionTypeListViewModel
    {
        public IList<ProductionType> PostTypes { get; set; }
    }
}
