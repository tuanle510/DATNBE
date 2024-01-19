using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Services
{
    public class ClientService : BaseService<ClientEntity>, IClientService
    {
        IClientRepository _clienttRepository;
        IContractRepository _contractRepository;

        public ClientService(
            IClientRepository clientRepository,
            IContractRepository contractRepository
            ) : base(clientRepository)
        {
            _clienttRepository = clientRepository;
            _contractRepository = contractRepository;

        }

        /// <summary>
        /// Gọi các danh sách liên quan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="master"></param>
        /// <returns></returns>
        public override object getDetailRef(Guid id, ClientEntity master)
        {
            var tab1 = _contractRepository.GetByMasterId(id, nameof(ClientEntity.client_id));
            var res = new
            {
                master = master,
                tab1 = tab1,
            };

            return res;
        }

        /// <summary>
        /// Check phát sinh khi xóa
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public override object? CheckArise(Guid guid)
        {
            var tab1 = _contractRepository.GetByMasterId(guid, nameof(ClientEntity.client_id));
            var res = new
            {
                contract = tab1.Count(),
            };

            return (tab1?.Count() == 0) ? null : res;
        }
    }
}
