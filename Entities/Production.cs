using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class Production : IEntity
    {
        public int ProductionId { get; set; }
        public int Title { get; set; }
        public int Description { get; set; }
        public string Slug { get; set; }
        public double ImdbScore { get; set; }
        public int MetaCriticScore { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ProductionTypeId { get; set; }
        public int StatusId { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Performer> Performers { get; set; }
    }
}
