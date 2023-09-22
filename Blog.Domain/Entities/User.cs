using Blog.Domain.Primitives;

namespace Blog.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public string Bio { get; set; }

        public List<Post> Posts { get; set; }
        public List<Role> Roles { get; set; }
    }
}