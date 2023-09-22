namespace Blog.Application.InputModels
{
    public record UpdateCategoryViewModel(Guid Id, string Title, string Slug)
    {
    }
}
