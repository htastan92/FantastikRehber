using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class PostType : IEntity
    {
        public int PostTypeId { get; set; }
        public string Title { get; set; }
    }
}
