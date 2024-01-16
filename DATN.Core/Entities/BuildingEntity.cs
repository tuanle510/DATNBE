using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("building")]
    public class BuildingEntity : BaseEntity
    {
        [PrimaryKey]
        public Guid building_id { get; set; }
        public string? building_name { get; set; }
        public string? building_address { get; set; }
        public string? province_code { get; set; }
        public string? province_name { get; set; }
        public string? district_code { get; set; }
        public string? district_name { get; set; }
        public string? ward_code { get; set; }
        public string? ward_name { get; set; }
    }
}
