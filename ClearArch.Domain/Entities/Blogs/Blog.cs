using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArch.Domain.Entities.Blogs
{
    public sealed class Blog
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }

    }
}