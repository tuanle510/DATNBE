using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Params
{
    public class ValidateError
    {
        public int Index { get; set; }
        public object? Data { get; set; }
        public string? Code { get; set; }
    }
}
