using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("apartment")]
    public class ApartmentEntity : BaseEntity
    {
        [PrimaryKey]
        public Guid apartment_id { get; set; }
        public string? apartment_name { get; set; }
        public string? apartment_address { get; set; }
        public Guid? owner_id { get; set; }
        public string? owner_name { get; set; }
        public Guid? building_id { get; set; }
        public string? building_name { get; set; }
        public string? note { get; set; }
        public string? description { get; set; }
    }
}
