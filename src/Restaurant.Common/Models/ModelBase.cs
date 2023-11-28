using Restaurant.Common.Models;

namespace Restaurant.Models
{
    public class ModelBase : IEntity
    {
        public Guid? Id { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
