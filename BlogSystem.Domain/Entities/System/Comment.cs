using BlogSystem.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Entities.System
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? AuthorId { get; set; }
        public AppUser Author { get; set; }
        public Guid? PostId { get; set; }
        public Post Post { get; set; }

    }
}
