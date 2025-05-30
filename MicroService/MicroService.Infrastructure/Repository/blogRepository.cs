using MicroServiceAPI.Domain.Entity;
using MicroServiceAPI.Domain.Repository;
using MicroService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MicroService.Infrastructure.Repository
{
    public class blogRepository : IblogRepository
    {
        private readonly BlogDbContext _context;

        public blogRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return 0;

            _context.Blogs.Remove(blog);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Blog>> GetALLBlogAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            var existing = await _context.Blogs.FindAsync(id);
            if (existing == null) return 0;

            existing.Name = blog.Name;
            existing.Author = blog.Author;
            existing.Description = blog.Description;
            return await _context.SaveChangesAsync();
        }
    }
}
