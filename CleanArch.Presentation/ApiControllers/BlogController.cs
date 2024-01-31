using AutoMapper;
using CleanArch.Application.Features.Commands.Blogs.CreateBlog;
using ClearArch.Domain.Entities.Blogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Presentation.ApiControllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private IMediator _mediator;
        private IMapper _mapper;

        public BlogController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
