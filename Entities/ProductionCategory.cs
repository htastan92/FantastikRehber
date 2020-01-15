using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class ProductionCategory : IEntity
    {
        public int ProductionId { get; set; }
        public Production Production { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
