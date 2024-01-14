using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Params
{
    public class FilterParam
    {
        public string columns { get; set; }
        public List<Filter>? filter { get; set; }
        public int take { get; set; }
        public int skip { get; set; }
    }
    public class TotalParam
    {
        public int total { get; set; }
    }

    public class FilterComhboboxParam
    {
        public string columns { get; set; }
        public string? filter { get; set; }
        public int take { get; set; }
        public int skip { get; set; }
    }
}
