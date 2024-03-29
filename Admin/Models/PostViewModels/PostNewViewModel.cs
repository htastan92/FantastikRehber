﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Admin.Models.PostViewModels
{
    public class PostNewViewModel
    {
        public int?  PostId { get; set; }
        [Display(Name = "Gönderi Başlığı")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        [MaxLength(120)]
        public string Description { get; set; }
        [Display(Name = "İçerik")]
        [DataType(DataType.Html)]
        public string EditorContent { get; set; }
        [DisplayName("Slug")]
        [Required()]
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Türü")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public int ProductionTypeId { get; set; }
        [Required]
        [Display(Name = "Durum")]
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        [Display(Name = "Kategoriler")]
        [Required]
        public IList<Category> Categories { get; set; }
        [Display(Name = "Resim")]
        [MaxLength(200)]
        public IList<IFormFile> Photos { get; set; }
    }
}
