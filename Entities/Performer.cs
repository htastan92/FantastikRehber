using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities
{
    public class Performer : IEntity
    {
        public int PerformerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string ImageUrl { get; set; }
        public string Information { get; set; }
        public string Slug { get; set; }
        public IList<Production> Productions { get; set; }
    }
}
