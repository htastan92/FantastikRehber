using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class Production : IEntity
    {
        public int ProductionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public double ImdbScore { get; set; }
        public int MetaCriticScore { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ProductionTypeId { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<ProductionCategory> ProductionCategories { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<ProductionPerformer> ProductionPerformers { get; set; }
    }
}
