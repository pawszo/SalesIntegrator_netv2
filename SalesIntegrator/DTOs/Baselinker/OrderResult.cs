namespace SalesIntegrator.Models
{
    public class OrderResult
    {
        public string status { get; set; }

        public Order[] orders { get; set; }
    }
}
