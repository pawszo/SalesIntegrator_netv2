using Newtonsoft.Json;
using SalesIntegrator.Dto.Interface;

namespace SalesIntegrator.Dto.Baselinker
{
    //[JsonObject()]
    public class OrderResultDto : IOrderResultDto
    {
        public string status { get; set; }

        public IOrderDto[] orders { get; set; }
    }
}
