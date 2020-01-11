using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductionPerformer
    {
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
        public int ProductionId { get; set; }
        public Production Production { get; set; }
    }
}
