using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("districts")]
    public class DistrictEntity
    {
        [PrimaryKey]
        public string district_code { get; set; }
        public string district_name { get; set; }
        public string district_full_name { get; set; }
        public string province_code { get; set; }
    }
}
