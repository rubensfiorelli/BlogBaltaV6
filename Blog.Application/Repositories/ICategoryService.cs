using Blog.Application.InputModels;
using Blog.Application.ViewModels;

namespace Blog.Application.Repositories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetId(Guid id);
        Task<CategoryViewModel> Add(CategoryInputModel model);
        Task<CategoryViewModel> Put(Guid categoryId, UpdateCategoryViewModel model);
    }
}
