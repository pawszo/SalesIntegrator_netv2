using SalesIntegrator.Dto.Baselinker;
using SalesIntegrator.Dto.Interface;
using SalesIntegrator.DTOs;
using SalesIntegrator.Dto.Interfaces;
using SalesIntegrator.Model;
using SalesIntegrator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesIntegrator.Service.Interface
{
    public interface IAPIService
    {
        Task<IEnumerable<IModel>> GetOrders(IOrderInputDto input);

    }
}
