using ClearArch.Domain.Entities.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Result>
    {

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


    }
}
