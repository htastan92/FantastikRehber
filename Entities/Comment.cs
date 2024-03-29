﻿using System;
using Core.Entities;

namespace Entities
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int MemberId { get; set; }
        public int StatusId { get; set; }
        public int PostId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
