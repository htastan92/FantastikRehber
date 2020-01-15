using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class ProductionPerformer : IEntity
    {
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
        public int ProductionId { get; set; }
        public Production Production { get; set; }
    }
}
