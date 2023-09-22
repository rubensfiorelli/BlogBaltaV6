using Blog.Domain.Primitives;

namespace Blog.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }

        public List<Post> Posts { get; set; }
    }
}