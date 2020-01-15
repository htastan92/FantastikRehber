using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Admin.Models.PerformerViewModels
{
    public class PerformerEditViewModel
    {
        public int PerformerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string ImageUrl { get; set; }
        public string Information { get; set; }
        public string Slug { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<IFormFile> Photos { get; set; }
    }
}
