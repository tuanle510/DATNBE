using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("contract_service")]
    public class ContractServiceEntity
    {
        [PrimaryKey]
        public Guid contract_service_id { get; set; }
        /// <summary>
        /// id hợp đồng
        /// </summary>
        [MasterKey]
        public Guid? contract_id { get; set; }
        public Guid? service_id { get; set; }
        public string? service_name { get; set; }
        public string? service_code { get; set; }
        public decimal? unit_price { get; set; }
        /// <summary>
        /// Định mứuc
        /// </summary>
        public string? dimension { get; set; }
        /// <summary>
        /// Kỳ thanh toán
        /// </summary>
        public int? payment_period { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string? note { get; set; }
        public int? sort_order { get; set; }
        /// <summary>
        /// Trạng thái thêm/sửa/xóa
        /// </summary>
        [Ignore]
        public string? state { get; set; }
    }
}
