using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.ProductionViewModels
{
    public class ProductionListViewModel
    {
        public IList<Production> Productions { get; set; }
    }
}
