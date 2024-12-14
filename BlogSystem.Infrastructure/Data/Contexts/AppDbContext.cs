using BlogSystem.Domain.Entities.Identity;
using BlogSystem.Domain.Entities.System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Infrastructure.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        DbSet<AppUser> appUsers { get; set; }
        DbSet<Post> posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Tag> Tags { get; set; }

    }
}
