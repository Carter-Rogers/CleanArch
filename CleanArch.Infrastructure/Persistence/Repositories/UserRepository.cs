using CleanArch.Application.Repositories;
using CleanArch.Infrastructure.Contexts;
using ClearArch.Domain.Entities.Result;
using ClearArch.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApiContext _context;

        public UserRepository(ApiContext context)
        {
            this._context = context;
        }

        public async Task<Result> CreateUser(User user)
        {
            var result = new Result();

            if (user is not null)
            {
                try
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();


                    result.Success = true;
                    result.Message = $"User added succesfully: {user.UserId}";
                    result.ResultObject = user;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = $"Failed to create user {user.UserId}\nUnhandled Exception Occurred:\n{ex.Message}";
                }

            }
            else
            {
                result.Success = false;
                result.Message = "User object is null!";
            }

            return result;
        }

        public async Task<Result> GetAllUsers()
        {
            var result = new Result();

            try
            {
                var list = _context.Users.AsQueryable();
                result.ResultList = list;
                result.Success = true;
                result.Message = "Succesfully retrieved user list";
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = $"Failed to get user list\nAn unhandled exception occurred:\n{ex.Message}";
            }

            


            return result;
        }

        public async Task<Result> UpdateUser(Guid id, User user)
        {
            var result = new Result();

            var match = await _context.Users.FindAsync(id);

            if (match is not null)
            {
                match.FirstName = user.FirstName;
                match.LastName = user.LastName;
                match.Email = user.Email;

                try
                {
                    _context.Users.Update(match);
                    await _context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = $"Updated user {id.ToString()} succesfully!";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = $"Failed to update user {id.ToString()}\nAn Unhandled Exception Occurred:\n{ex.Message}";
                }
            }
            else
            {
                result.Success = false;
                result.Message = $"User {id.ToString()} Not Found!";
            }

            return result;
        }

        public async Task<Result> DeleteUser(Guid id)
        {
            var result = new Result();
            var match = await _context.Users.FindAsync(id);
            if (match is not null)
            {
                try
                {
                    _context.Users.Remove(match);
                    await _context.SaveChangesAsync();

                    result.Success = true;
                    result.Message = $"User {id.ToString()} Deleted Successfully!";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = $"Could Not Delete User {id.ToString()}\nAn Unhandled Exception Occurred:\n{ex.Message}";
                }
            }else
            {
                result.Success = false;
                result.Message = $"User {id.ToString()} Not Found!";
            }

            return result;
        }

        public async Task<Result> FindUserById(Guid id)
        {
            var result = new Result();

            var match = await _context.Users.FindAsync(id);

            if(match is null)
            {
                result.Success = false;
                result.Message = $"Could not find user {id.ToString()}!";
            }else
            {
                result.Success = true;
                result.Message = "Found user succesfully.";
                result.ResultObject = match;
            }

            return result;
        }
    }
}
