using AutoMapper;
using CleanArch.Application.Repositories;
using ClearArch.Domain.Entities.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Queries.Users.FindById
{
    public class FindUserByIdRequest : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

    public class FindUserByIdRequestHandler : IRequestHandler<FindUserByIdRequest, Result>
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public FindUserByIdRequestHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<Result> Handle(FindUserByIdRequest request, CancellationToken cancellationToken)
        {
            return await _userRepo.FindUserById(request.Id);
        }
    }

}