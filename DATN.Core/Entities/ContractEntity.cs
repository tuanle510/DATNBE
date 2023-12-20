using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("contract")]
    public class ContractEntity
    {
        [PrimaryKey]
        public Guid contract_id { get; set; }
        /// <summary>
        /// Căn hộ
        /// </summary>
        public Guid? apartment_id { get; set; }
        public string? apartment_name { get; set; }
        /// <summary>
        /// Chủ nhà
        /// </summary>
        public Guid? owner_id { get; set; }
        public string? owner_name { get; set; }
        /// <summary>
        /// Bộ hồ sơ
        /// </summary>
        public Guid? contract_group_id { get; set; }
        public string? contract_group_name { get; set; }
        /// <summary>
        /// Khách hàng
        /// </summary>
        public Guid? client_id { get; set; }
        public string? client_name { get; set; }
        /// <summary>
        /// Giá thuê / tháng
        /// </summary>
        public decimal? unit_price { get; set; }  
        /// <summary>
        /// Tiền cọc
        /// </summary>
        public decimal? deposit_amount { get; set; }
        /// <summary>
        /// Điều  kiện ra hạn
        /// </summary>
        public string? extension_condition { get; set; }
        /// <summary>
        /// Ngày bắt đầu hợp đồng
        /// </summary>
        public DateTime? start_date { get; set; }
        /// <summary>
        /// Ngày kêt thúc
        /// </summary>
        public DateTime? end_date { get; set; }
        /// <summary>
        /// Kỳ thanh toán (Bao lâu thanh toán 1 lần)
        /// </summary>
        public int? payment_period { get; set; }
        /// <summary>
        /// Ngày nhận nhà
        /// </summary>
        public DateTime? receive_date { get; set; }
        /// <summary>
        /// Ngày trả nhà
        /// </summary>
        public DateTime? return_date { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string? note { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public string? modified_by { get; set; }
            
    }
}
