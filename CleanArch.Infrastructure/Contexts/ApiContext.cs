using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Contexts
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> dbContextOptions) : base(dbContextOptions) { }

        public virtual DbSet<ClearArch.Domain.Entities.Users.User> Users { get; set; }
        public virtual DbSet<ClearArch.Domain.Entities.Blogs.Blog> Blogs { get; set; }

    }
}