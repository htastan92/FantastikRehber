using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.PerformerViewModels
{
    public class PerformerListViewModel
    {
        public IList<Performer> Performers { get; set; }
    }
}
