using System;
using System.Collections.Generic;
using System.Net.Http;
using RestSharp;
using System.Linq;
using SalesIntegrator.Models;
using System.Text.Json;
using System.Net;
using SalesIntegrator.Utils;
using System.Threading.Tasks;
using SalesIntegrator.Interfaces;

namespace SalesIntegrator.Services
{
    public class BaselinkerService : IOrderService
    {
        private readonly IDataService _dataService;
        public BaselinkerService(IDataService dataService) => _dataService = dataService;

        public async Task<IEnumerable<Order>> GetOrders(OrderInput input)
        {
            var client = new RestClient(Constants.BASELINKER_URI);
            var request = new RestRequest(Method.POST);
            request.AddParameter("token", _dataService.Token);
            request.AddParameter("method", Constants.GET_ORDERS_METHOD);
            request.AddParameter("parameters", JsonSerializer.Serialize(input, JsonUtils.JSON_OPTIONS));

            var response = await client.ExecuteAsync(request); 
            if (response.StatusCode != HttpStatusCode.OK) throw new HttpRequestException();

            var result = JsonSerializer.Deserialize<OrderResult>(response.Content);
            return result?.orders?.AsEnumerable<Order>(); 

        }

    }
}
