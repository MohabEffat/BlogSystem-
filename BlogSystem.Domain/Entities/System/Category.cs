﻿using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Entities.System
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}