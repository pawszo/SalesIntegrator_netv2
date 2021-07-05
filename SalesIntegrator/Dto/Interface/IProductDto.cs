using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Interface
{
    public interface IProductDto : IDto
    {
        string storage { get; set; }
        string storage_id { get; set; }
        string order_product_id { get; set; }
        string product_id { get; set; }
        string variant_id { get; set; }
        string name { get; set; }
        string attributes { get; set; }
        string sku { get; set; }
        string ean { get; set; }
        string auction_id { get; set; }
        float price_brutto { get; set; }
        int tax_rate { get; set; }
        int quantity { get; set; }
        float weight { get; set; }
    }
}
