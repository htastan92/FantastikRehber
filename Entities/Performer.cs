using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class Performer : IEntity
    {
        public int PerformerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
        public DateTime Birthdate { get; set; }
        public string ImageUrl { get; set; }
        public string Information { get; set; }
        public string Slug { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<ProductionPerformer> ProductionPerformers { get; set; }
    }
}
