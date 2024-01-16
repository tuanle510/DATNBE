using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("provinces")]
    public class ProvinceEntity
    {
        [PrimaryKey]
        public string province_code { get; set; }
        public string province_name { get; set; }
        public string province_full_name { get; set; }
    }
}
