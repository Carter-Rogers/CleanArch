using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using CleanArch.Application.Features.Commands.Users;
using CleanArch.Application.Features.Queries.Users;
using CleanArch.Application.Features.Commands.Users.UpdateUser;
using CleanArch.Application.Features.Commands.Users.RemoveUser;
using CleanArch.Application.Features.Queries.Users.FindById;

namespace CleanArch.Presentation.ApiControllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IMediator _mediator;
        private IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllUsers()
        {
            var query = new FindUsersRequest();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(Guid id, string FirstName, string LastName, string email)
        {
            UpdateUserCommand command = new UpdateUserCommand
            {
                UserId = id,
                FirstName = FirstName,
                LastName = LastName,
                Email = email
            };

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(RemoveUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("finduserbyid")]
        public async Task<IActionResult> FindUserById(Guid id)
        {
            var command = new FindUserByIdRequest();
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }


    }
}