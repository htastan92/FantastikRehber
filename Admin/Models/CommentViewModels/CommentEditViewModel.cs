using System;
using Entities;

namespace Admin.Models.CommentViewModels
{
    public class CommentEditViewModel
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int MemberId { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int PostId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
