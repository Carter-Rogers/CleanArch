using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArch.Domain.Entities.Result
{
    public sealed class Result
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public IQueryable<Object>? ResultList { get; set; }

        public Object? ResultObject { get; set; }

    }
}