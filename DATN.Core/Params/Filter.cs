using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Params
{
    public class Filter
    {
        public string? value { get; set; }
        public string op { get; set; }
        public string field { get; set; }
    }
}
