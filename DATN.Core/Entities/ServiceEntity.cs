using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("service")]
    public class ServiceEntity
    {
        [PrimaryKey]
        public Guid service_id { get; set; }
        public string? service_name { get; set; }
        public string? service_code { get; set; }
    }
}
