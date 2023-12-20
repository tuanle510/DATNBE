using DATN.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    [TableName("apartment")]
    public class ApartmentEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        public Guid apartment_id { get; set; }
        public string? apartment_name { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? apartment_address { get; set; }
        /// <summary>
        /// id chủ sở hữu
        /// </summary>
        public Guid? owner_id { get; set; }
        /// <summary>
        /// Tên chủ sở hữu
        /// </summary>
        public string? owner_name { get; set; }
        /// <summary>
        /// id Tòa nhà 
        /// </summary>
        public Guid? building_id { get; set; }
        /// <summary>
        /// Tên tòa nhà
        /// </summary>
        public string? building_name { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string? note { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string? description { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public string? modified_by { get; set; }

    }
}
