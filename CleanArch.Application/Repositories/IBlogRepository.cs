using ClearArch.Domain.Entities.Blogs;
using ClearArch.Domain.Entities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Repositories
{
    public interface IBlogRepository
    {

        Task<Result> CreateBlog(Blog blog);

        Task DeleteBlog(Guid blogId);

        Task UpdateBlog(Guid blogId, Features.Commands.Blogs.UpdateBlog.UpdateBlogCommand recordChange);

    }
}
