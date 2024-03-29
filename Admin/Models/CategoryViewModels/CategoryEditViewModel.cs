﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Admin.Models.CategoryViewModels
{
    public class CategoryEditViewModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public int PostTypeId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public IList<IFormFile> Photos { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
