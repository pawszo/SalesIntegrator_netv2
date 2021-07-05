using System;
using System.Collections.Generic;
using System.Net.Http;
using RestSharp;
using System.Linq;
using SalesIntegrator.Model;
using System.Text.Json;
using System.Net;
using SalesIntegrator.Utils;
using System.Threading.Tasks;
using SalesIntegrator.Service.Interface;
using SalesIntegrator.Dto.Baselinker;
using SalesIntegrator.Mapper.Interface;
using SalesIntegrator.Mapper;
using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Model.Interface;

namespace SalesIntegrator.Service
{
    public class BaselinkerService : IAPIService
    {
        private readonly IDataService _dataService;
        private readonly IMapper _baselinkerMapper;
        public BaselinkerService(IDataService dataService, IEnumerable<IMapper> mappers)
        {
            _dataService = dataService;
            _baselinkerMapper = mappers.First(p => p is BaselinkerMapper);
        }

        public async Task<IEnumerable<IModel>> GetOrders(IOrderInputDto input)
        {
            var client = new RestClient(Constants.BASELINKER_URI);
            var request = new RestRequest(Method.POST);
            request.AddParameter("token", _dataService.Token);
            request.AddParameter("method", Constants.GET_ORDERS_METHOD);
            request.AddParameter("parameters", JsonSerializer.Serialize(input, JsonUtils.JSON_OPTIONS));

            var response = await client.ExecuteAsync(request); 
            if (response.StatusCode != HttpStatusCode.OK) throw new HttpRequestException();

            var result = JsonSerializer.Deserialize<OrderResultDto>(response.Content);

            var orders = result?.orders?.AsEnumerable<IOrderDto>();

            return orders.Select(p => _baselinkerMapper.MapToModel(p));

        }

    }
}
