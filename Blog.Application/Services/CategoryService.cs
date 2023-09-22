using Blog.Application.InputModels;
using Blog.Application.Repositories;
using Blog.Application.ViewModels;
using Blog.Domain.Repositories;

namespace Blog.Application.Services
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryViewModel> Add(CategoryInputModel model)
        {
            var category = model.ToEntity();

            await _categoryRepository.AddAsync(category);

            await _categoryRepository.Commit();

            return CategoryViewModel.FromEntity(category);
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var categories = await _categoryRepository.GetAsync();

            return categories
                .Select(x => new CategoryViewModel(x.Id, x.Title, x.Slug, x.CreatedAt))
                .ToList();
        }

        public async Task<CategoryViewModel> GetId(Guid id)
        {
            var category = await _categoryRepository.GetIdAsync(id);

            return CategoryViewModel.FromEntity(category);

        }

        public async Task<CategoryViewModel> Put(Guid categoryId, UpdateCategoryViewModel model)
        {

            var category = await _categoryRepository.GetIdAsync(categoryId);

            category.SetCategory(model.Title, model.Slug);

            if(model != null)
                await _categoryRepository.UpdateAsync(category);

            await _categoryRepository.Commit();

            return CategoryViewModel.FromEntity(category);

        }

       
    }
}
