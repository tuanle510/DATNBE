using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    public class AuthEntiry
    {
        public Guid? user_id { get; set; }
        public string? user_name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }

    }
}
