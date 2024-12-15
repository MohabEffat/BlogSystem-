using BlogSystem.Domain.Entities.System;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace BlogSystem.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
