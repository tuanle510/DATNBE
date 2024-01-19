using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Params
{
    public class DashBoardParam
    {
        public int apartment_records { get; set; }
        public int client_records { get; set; }
        public int building_count { get; set; }
        public int owner_count { get; set; }
    };

    public class DashBoardChartParam
    {
        public int month { get; set; }
        public int total_records { get; set; }
    };
    
    public class DashBoardCircleParam
    {
        public string contract_type { get; set; }
        public int total_records { get; set; }
    }
}
