using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.PostViewModels
{
    public class PostListViewModel
    {
        public IList<Post> Posts { get; set; }
    }
}
