using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infrastructure.Repository
{
    public class ApartmentRepository : BaseRepository<ApartmentEntity>, IApartmentRepository
    {
        public ApartmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
