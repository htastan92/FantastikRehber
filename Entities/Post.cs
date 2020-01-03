using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Post : IEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public IList<PostPhoto> PostPhotos { get; set; }
    }
}
