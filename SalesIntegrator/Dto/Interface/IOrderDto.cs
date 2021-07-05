using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Interface
{
    public interface IOrderDto : IDto
    {
        int order_id { get; set; }
        string shop_order_id { get; set; }
        string external_order_id { get; set; }
        string order_source { get; set; }
        string order_source_id { get; set; }
        string order_source_info { get; set; }
        int order_status_id { get; set; }
        bool confirmed { get; set; }
        int date_confirmed { get; set; }
        int date_add { get; set; }
        int date_in_status { get; set; }
        string user_login { get; set; }
        string phone { get; set; }
        string email { get; set; }
        string user_comments { get; set; }
        string admin_comments { get; set; }
        string currency { get; set; }
        string payment_method { get; set; }
        string payment_method_cod { get; set; }
        float payment_done { get; set; }
        string delivery_method { get; set; }
        float delivery_price { get; set; }
        string delivery_package_module { get; set; }
        string delivery_package_nr { get; set; }
        string delivery_fullname { get; set; }
        string delivery_company { get; set; }
        string delivery_address { get; set; }
        string delivery_city { get; set; }
        string delivery_postcode { get; set; }
        string delivery_country_code { get; set; }
        string delivery_point_id { get; set; }
        string delivery_point_name { get; set; }
        string delivery_point_address { get; set; }
        string delivery_point_postcode { get; set; }
        string delivery_point_city { get; set; }
        string invoice_fullname { get; set; }
        string invoice_company { get; set; }
        string invoice_nip { get; set; }
        string invoice_address { get; set; }
        string invoice_city { get; set; }
        string invoice_postcode { get; set; }
        string invoice_country_code { get; set; }
        string want_invoice { get; set; }
        string extra_field_1 { get; set; }
        string extra_field_2 { get; set; }
        string order_page { get; set; }
        int pick_state { get; set; }
        int pack_state { get; set; }
        string delivery_country { get; set; }
        string invoice_country { get; set; }
        IProductDto[] products { get; set; }
    }
}
