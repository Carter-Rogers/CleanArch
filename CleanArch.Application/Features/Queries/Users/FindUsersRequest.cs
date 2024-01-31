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

namespace CleanArch.Application.Features.Queries.Users
{
    public class FindUsersRequest : IRequest<Result>
    {
    }

    public class FindUsersRequestHandler : IRequestHandler<FindUsersRequest, Result>
    {

        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public FindUsersRequestHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<Result> Handle(FindUsersRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepo.GetAllUsers();
            return result;
        }
    }

}
