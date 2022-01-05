using System.ComponentModel.DataAnnotations;

namespace Quiz.Model
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public int Counter { get; set; }
    }
}