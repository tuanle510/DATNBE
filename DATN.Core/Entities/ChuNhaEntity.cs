using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    public class ChuNhaEntity
    {
        [PrimaryKey]
        public Guid id { get; set; }
        public string name { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string phone_number { get; set; }
        public string paper_number { get; set; }
        public string paper_date { get; set; }
        public string paper_place { get; set; }
        public string bank_account_number { get; set; }
        public string bank_account_name { get; set; }
        public string bank_account_location { get; set; }
        public string bank_name { get; set; }

    }
}
