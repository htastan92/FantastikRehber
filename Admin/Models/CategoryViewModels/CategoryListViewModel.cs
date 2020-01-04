using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.CategoryViewModels
{
    public class CategoryListViewModel
    {
        public IList<Category> Categories { get; set; }
    }
}
