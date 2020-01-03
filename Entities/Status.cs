using Core.Entities;

namespace Entities
{
    public class Status : IEntity
    {
        public int StatusId { get; set; }
        public string Title { get; set; }
    }
}
