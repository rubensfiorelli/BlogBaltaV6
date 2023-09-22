using Blog.Domain.Entities;

namespace Blog.Application.InputModels
{
    public sealed class CategoryInputModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }

        public Category ToEntity()
            => new Category(Title, Slug);
    }
}
