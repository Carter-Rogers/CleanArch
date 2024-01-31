using ClearArch.Domain.Entities.Result;
using ClearArch.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Repositories
{
    public interface IUserRepository
    {

        Task<Result> CreateUser(User user);
        Task<Result> GetAllUsers();

        Task<Result> UpdateUser(Guid id, User user);

        Task<Result> DeleteUser(Guid id);

        Task<Result> FindUserById(Guid id);

    }
}
