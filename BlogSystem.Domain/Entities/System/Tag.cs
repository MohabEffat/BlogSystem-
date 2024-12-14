using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Entities.System
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
