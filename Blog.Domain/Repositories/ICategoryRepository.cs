using Blog.Domain.Entities;

namespace Blog.Domain.Repositories
{
    public interface ICategoryRepository : IUnitOfWork
    {
        Task<List<Category>> GetAsync();
        Task<Category> GetIdAsync(Guid id);
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);

    }
}
