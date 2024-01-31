using CleanArch.Application.Features.Commands.Blogs.UpdateBlog;
using CleanArch.Application.Repositories;
using CleanArch.Infrastructure.Contexts;
using ClearArch.Domain.Entities.Blogs;
using ClearArch.Domain.Entities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistence.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApiContext _context;

        public BlogRepository(ApiContext context) 
        {
            this._context = context;
        }

        public async Task<Result> CreateBlog(Blog blog)
        {
            var result = new Result();

            var match = await _context.Blogs.FindAsync(blog.Id);
            if(match is null)
            {
                try
                {
                    await _context.Blogs.AddAsync(blog);
                    await _context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = $"Created blog successfully {blog.Id}";
                    result.ResultObject = blog;
                }catch(Exception ex)
                {
                    result.Success = false;
                    result.Message = $"Failed to create Blog {blog.Id}\nUnhandled Exception Occurred:\n{ex.Message}";
                }
            }else
            {
                result.Success = false;
                result.Message = $"Blog {blog.Id} already exists!";
            }

            return result;
        }

        public Task DeleteBlog(Guid blogId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBlog(Guid blogId, UpdateBlogCommand recordChange)
        {
            throw new NotImplementedException();
        }
    }
}
