using System.ComponentModel.DataAnnotations;

namespace DefendersDeck.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
