using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Admin.Models.ProductionViewModels
{
    public class ProductionNewViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public double ImdbScore { get; set; }
        public string ImageUrl { get; set; }
        public int MetaCriticScore { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ProductionTypeId { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<IFormFile> Photos { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Performer> Performers { get; set; }
    }
}
