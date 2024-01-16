using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("wards")]
    public class WardEntity
    {
        [PrimaryKey]
        public string ward_code { get; set; }
        public string ward_name { get; set; }
        public string ward_full_name { get; set; }
        public string district_code { get; set; }

    }
}
