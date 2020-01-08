using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Admin.Models.CategoryViewModels
{
    public class CategoryNewViewModel
    {
        [DisplayName("Kategori Adı")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [DisplayName("Kategori Açıklaması")]
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [DisplayName("Slug")]
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [DisplayName("Post Türü")]
        public int PostTypeId { get; set; }
        [Required]
        [DisplayName("Durum")]
        public int StatusId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        [DisplayName("Fotoğraf")]
        public IList<IFormFile> Photos { get; set; }
        public IList<Status> Statuses { get; set; }
    }
}
