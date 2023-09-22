using Blog.DatabaseContext;
using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category category)
        {
            category.CreatedAt = DateTime.UtcNow;

            await _context.AddAsync(category);

            return category;

        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Category>> GetAsync()
        {
            var categories = await _context.Categories
                .ToListAsync();

            return categories;
        }

        public async Task<Category> GetIdAsync(Guid id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(id));

            if (category is null)
                return null;

            return category;
        }


        public Task Rollback()
        {
            return Task.CompletedTask;
        }


        public async Task<Category> UpdateAsync(Category category)
        {

            var result = await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(category.Id));

            if (result is null)
                return null;

            category.UpdatedAt = DateTime.UtcNow;
            category.CreatedAt = result.CreatedAt;

            _context.Entry(result).CurrentValues.SetValues(category);

            return category;
        }
    }
}
