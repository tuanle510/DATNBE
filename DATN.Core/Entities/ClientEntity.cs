using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("client")]
    public class ClientEntity
    {
        [PrimaryKey]
        public Guid client_id { get; set; }
        public string? client_name { get; set; }
        public DateTime birthdate { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        /// <summary>
        /// Công ty
        /// </summary>
        public string? company_name { get; set; }
        public string? company_phone { get; set; }
        public string? company_tax_code { get; set; }
        public string? company_fax { get; set; }
        public string? company_address { get; set; }
        /// <summary>
        /// Đại diện công ty
        /// </summary>
        public string? company_ref { get; set; }
        /// <summary>
        /// Vai trò người đại diện công ty
        /// </summary>
        public string? company_ref_role { get; set; }
        /// <summary>
        /// Trợ lý
        /// </summary>
        public string? assistant_name { get; set; }
        public string? assistant_phone { get; set; }
        public string? assistant_email { get; set; }
        
        /// <summary>
        /// Giấy tờ
        /// </summary>
        public string? paper_number { get; set; }
        public DateTime paper_date { get; set; }
        public string? paper_place { get; set; }
        public string? note { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public string? modified_by { get; set; }
    }
}
