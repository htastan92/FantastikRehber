using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.PostTypeViewModels
{
    public class PostTypeListViewModel
    {
        public IList<PostType> PostTypes { get; set; }
    }
}
