using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Params
{
    public class ContractGroupParam
    {
        public  ContractGroupEntity master { get; set; }
        public List<ContractEntity>? details { get; set; }
    }
}
