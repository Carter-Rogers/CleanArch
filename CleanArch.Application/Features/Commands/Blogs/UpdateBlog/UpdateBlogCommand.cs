using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.Blogs.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<UpdateBlogCommandResponse>
    {

        Guid Id { get; set; }

        String Content { get; set; } = string.Empty;

        Guid AuthorId { get; set; }


    }

    public class UpdateBlogCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
