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

namespace CleanArch.Application.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            try
            {
                result = await _userRepo.UpdateUser(request.UserId, new User 
                { 
                    FirstName = request.FirstName, LastName = request.LastName, Email = request.Email
                });

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Unexpected Error Occured:\n{ex.Message}";
            }


            return result;
        }
    }
}
