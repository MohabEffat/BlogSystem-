namespace BlogSystem.Domain.Entities.System
{
    public class PostTag
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? PostId { get; set; }
        public Guid? TagId { get; set; }
        public Tag Tag { get; set; }
        public Post Post { get; set; }

    }
}
