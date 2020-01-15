using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class PostCategory : IEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
