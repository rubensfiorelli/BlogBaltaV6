using Blog.Domain.Primitives;

namespace Blog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category(string title, string slug)
        {
            Title = title;
            Slug = slug;

            Posts = new List<Post>();
        }

        public string Title { get; private set; }
        public string Slug { get; private set; }

        public List<Post> Posts { get; set; }

        public void SetCategory(string newTitle, string newSlug)
        {
            Title = newTitle;
            Slug = newSlug;
        }

    }
}