using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public IList<Photo> Photos { get; set; }
    }
}
