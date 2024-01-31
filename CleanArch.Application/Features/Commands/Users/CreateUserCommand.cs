using ClearArch.Domain.Entities.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.Users
{
    public class CreateUserCommand : IRequest<Result>
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

    }
}