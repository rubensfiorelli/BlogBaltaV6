using Blog.Domain.Entities;

namespace Blog.Application.ViewModels
{
    public record CategoryViewModel(Guid Id, string Title, string Slug, DateTimeOffset CreatedAt)
    {
        public static CategoryViewModel FromEntity(Category category)
        {
            return new CategoryViewModel(
                category.Id,
                category.Title,
                category.Slug,
                category.CreatedAt);
        }
    }
}
