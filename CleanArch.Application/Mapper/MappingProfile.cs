using AutoMapper;
using CleanArch.Application.Features.Commands.Blogs.CreateBlog;
using CleanArch.Application.Features.Commands.Users;
using CleanArch.Application.Features.Commands.Users.UpdateUser;
using ClearArch.Domain.Entities.Blogs;
using ClearArch.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile() {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
        }
   

    }
}
