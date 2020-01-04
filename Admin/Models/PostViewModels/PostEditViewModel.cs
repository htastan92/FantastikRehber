using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models.PostViewModels
{
    public class PostEditViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<PostPhoto> PostPhotos { get; set; }

    }
}
