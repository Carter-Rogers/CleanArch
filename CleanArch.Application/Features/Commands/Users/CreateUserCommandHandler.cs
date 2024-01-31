using AutoMapper;
using CleanArch.Application.Repositories;
using ClearArch.Domain.Entities.Result;
using ClearArch.Domain.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {

        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            try
            {
                var record = _mapper.Map<User>(request);
                record.UserId = Guid.NewGuid();
                record.FirstName = request.FirstName;
                record.LastName = request.LastName;

                result = await _userRepo.CreateUser(record);
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = $"Unexpected Error Occured:\n{ex.Message}";
            }

            return result;
        }
    }
}
