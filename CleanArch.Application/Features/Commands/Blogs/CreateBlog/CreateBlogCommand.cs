using AutoMapper;
using CleanArch.Application.Repositories;
using ClearArch.Domain.Entities.Blogs;
using ClearArch.Domain.Entities.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.Blogs.CreateBlog
{
    public class CreateBlogCommand : IRequest<Result>
    {

        public string Content { get; set; } = string.Empty;

        [Required]
        public Guid AuthorId { get; set; }


    }

    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repository;

        public CreateBlogCommandHandler(IMapper mapper, IBlogRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public async Task<Result> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            try
            {
                Blog b = new Blog();
                b.Id = Guid.NewGuid();
                b.AuthorId = request.AuthorId;
                b.Content = request.Content;

                var response = await _repository.CreateBlog(b);
                result = response;
            }catch(Exception ex)
            {
                result.Success = false;
                result.Message = $"Failed to create blog!\nUnexpected Error Occured:\n{ex.Message}";
            }

            return result;
        }
    }

}