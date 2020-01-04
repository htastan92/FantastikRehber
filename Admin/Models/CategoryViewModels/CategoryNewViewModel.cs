using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.CategoryViewModels
{
    public class CategoryNewViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
