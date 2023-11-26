using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("chu_nha")]
    public class ChuNhaEntity
    {
        [PrimaryKey]
        public Guid owner_id { get; set; }
        public string owner_name { get; set; }
        public DateTime birthdate { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string paper_number { get; set; }
        public DateTime paper_date { get; set; }
        public string paper_place { get; set; }
        public string? bank_account_number { get; set; }
        public string? bank_account_name { get; set; }
        public string? bank_account_location { get; set; }
        public string? bank_name { get; set; }

    }
}
