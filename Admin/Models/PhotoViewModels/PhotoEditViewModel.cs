﻿using System;
using System.Collections.Generic;
using Entities;

namespace Admin.Models.PhotoViewModels
{
    public class PhotoEditViewModel
    {
        public int PhotoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Slug { get; set; }
        public int StatusId { get; set; }
        public int CategoryId { get; set; }
        public int MemberId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<PostPhoto> PostPhotos { get; set; }
    }
}
