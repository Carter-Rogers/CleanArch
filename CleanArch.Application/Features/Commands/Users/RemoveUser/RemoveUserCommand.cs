using AutoMapper;
using CleanArch.Application.Repositories;
using ClearArch.Domain.Entities.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.Users.RemoveUser
{
    public class RemoveUserCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }

    }

    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Result>
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public RemoveUserCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<Result> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();
            try
            {
                result = await _userRepo.DeleteUser(request.UserId);

            }
            catch (Exception ex) {
                result.Success = false;
                result.Message = $"An Unexpected Error Occured:\n{ex.Message}";
            }

            return result;
        }
    }

}