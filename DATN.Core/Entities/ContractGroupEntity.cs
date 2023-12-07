using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("contract_group")]
    public class ContractGroupEntity
    {
        [PrimaryKey]
        public Guid contract_group_id { get; set; }

        public string contract_group_name { get; set; }

        public Guid apartment_id { get; set; }
        public string apartment_name { get; set; }

        public Guid owner_id { get; set; }
        public string owner_name { get; set; }
    }
}
