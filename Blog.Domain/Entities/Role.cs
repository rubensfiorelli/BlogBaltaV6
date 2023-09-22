using Blog.Domain.Primitives;
using System.Collections.Generic;

namespace Blog.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }

        public List<User> Users { get; set; }
    }
}