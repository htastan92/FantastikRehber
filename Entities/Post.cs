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
        public string EditorContent { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TypeId { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<PostCategory> PostCategories { get; set; }
    }
}
