﻿using DATN.Core.Attributes;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Lấy dữ liệu entity mói
        /// </summary>
        /// <returns></returns>
        public T GetNew()
        {
            Type type = typeof(T);
            T entity = (T)Activator.CreateInstance(type);
            var properties = typeof(T).GetProperties();
            var prop = type.GetProperties().Where(e => e.IsDefined(typeof(PrimaryKey))).FirstOrDefault();
            prop.SetValue(entity, Guid.NewGuid());
            return entity;
        }

        public int InsertService(T entity)
        {
            throw new NotImplementedException();
        }

        public int UpdateService(Guid entityId, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
