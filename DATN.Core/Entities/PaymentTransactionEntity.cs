using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("payment_transaction")]
    public class PaymentTransactionEntity
    {
        [PrimaryKey]
        public Guid payment_transaction_id { get; set; }
        /// <summary>
        /// Mã hợp đồng
        /// </summary>
        public Guid? contract_id { get; set; }
        /// <summary>
        /// Đợt thanh toán
        /// </summary>
        public string? payment_batch { get; set; }
        /// <summary>
        /// Số tiền
        /// </summary>
        public decimal? amount { get; set; }
        /// <summary>
        /// GHi chú
        /// </summary>
        public string? note { get; set; }
        /// <summary>
        /// Ngày bắt đầu kỳ thành toán
        /// </summary>
        public DateTime? start_date { get; set; }
        /// <summary>
        /// Ngày kết thúc kỳ thành toán
        /// </summary>
        public DateTime? end_date { get; set; }
        /// <summary>
        /// Ngày thanh toán dự định
        /// </summary>
        public DateTime? expected_payment_date { get; set; }
        public DateTime? real_payment_date { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public string? status { get; set; }
        /// <summary>
        /// Người gửi
        /// </summary>
        public string? sender_id { get; set; }
        public string? sender_name { get; set; }
        /// <summary>
        /// Người nhận
        /// </summary>
        public Guid? receive_id { get; set; }
        public string? receiver_name { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public string? modified_by { get; set; }
        /// <summary>
        /// Trạng thái thêm/sửa/xóa
        /// </summary>
        [Ignore]
        public string? mode { get; set; }

    }
}
