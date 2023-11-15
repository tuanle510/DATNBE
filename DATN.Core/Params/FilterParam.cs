using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Params
{
    public class FilterParam
    {
        public string column { get; set; }
        public string? filter { get; set; }
        public int take { get; set; }
        public int skip { get; set; }
    }
}
