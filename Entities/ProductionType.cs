using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class ProductionType : IEntity
    {
        public int ProductionTypeId { get; set; }
        public string Title { get; set; }
  
    }
}
