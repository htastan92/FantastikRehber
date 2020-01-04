using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.CommentViewModels
{
    public class CommentNewViewModel
    {
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
