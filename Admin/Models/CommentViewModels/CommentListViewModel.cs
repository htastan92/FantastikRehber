using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.CommentViewModels
{
    public class CommentListViewModel
    {
        public IList<Comment> Comments { get; set; }
    }
}
