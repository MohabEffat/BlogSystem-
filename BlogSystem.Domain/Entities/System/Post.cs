using BlogSystem.Domain.Entities.Identity;
using BlogSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Entities.System
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }
        public string? AuthorId { get; set; }
        public AppUser Author { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public Status status { get; set; }
        public ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
