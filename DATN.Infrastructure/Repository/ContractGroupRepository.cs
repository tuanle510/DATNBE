using Dapper;
using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Params;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infrastructure.Repository
{
    public class ContractGroupRepository : BaseRepository<ContractGroupEntity>, IContractGroupRepository
    {
        public ContractGroupRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// màn này không check 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override bool CheckArise(Guid param)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object GetDashboard(int year)
        {
            var parameters = new DynamicParameters();
            parameters.Add("$year", year);

            var res = _sqlConnection.QueryMultiple($"get_dashboard", param: parameters, commandType: CommandType.StoredProcedure);

            var dashBoard = res.Read<DashBoardParam>().ToList();
            var dashBoardChart = res.Read<DashBoardChartParam>().ToList();
            var dashBoardCircle = res.Read<DashBoardCircleParam>().ToList();
            return new { dashBoard, dashBoardChart, dashBoardCircle };
        }
    }
}
