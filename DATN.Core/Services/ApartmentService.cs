﻿using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Services
{
    public class ApartmentService : BaseService<ApartmentEntity>, IApartmentService
    {
        IApartmentRepository _apartmentRepository;
        public ApartmentService(IApartmentRepository apartmentRepository) : base(apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
    }
}
