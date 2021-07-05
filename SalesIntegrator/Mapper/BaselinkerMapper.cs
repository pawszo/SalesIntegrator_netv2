using SalesIntegrator.Dto;
using Baselinker = SalesIntegrator.Dto.Baselinker;
using SalesIntegrator.Dto.Interfaces;
using SalesIntegrator.Mapper.Interface;
using SalesIntegrator.Model;
using SalesIntegrator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIntegrator.Dto.Interface;

namespace SalesIntegrator.Mapper
{
    public class BaselinkerMapper : IMapper
    {
        public IDto MapToDto(IModel model)
        {
            switch(model)
            {
                case Order o:
                    return MapOrderToDto(o);
                case Product p:
                    return MapProductToDto(p);
                case OrderInput oi:
                    return MapOrderInputToDto(oi);
                case OrderResult or:
                    return MapOrderResultToDto(or);
                default: 
                    return null;

            }

        }
        public IModel MapToModel(IDto dto)
        {
            switch (dto)
            {
                case Baselinker.OrderDto o:
                    return MapOrderToModel(o);
                case Baselinker.ProductDto p:
                    return MapProductToModel(p);
                case Baselinker.OrderInputDto oi:
                    return MapOrderInputToModel(oi);
                case Baselinker.OrderResultDto or:
                    return MapOrderResultToModel(or);
                default:
                    return null;

            }
        }

        private Dto.Baselinker.OrderDto MapOrderToDto(Order model) =>
            new Dto.Baselinker.OrderDto
            {
                order_id = model.order_id,
                shop_order_id = model.shop_order_id,
                external_order_id = model.external_order_id,
                order_source = model.order_source,
                order_source_id = model.order_source_id,
                order_source_info = model.order_source_info,
                order_status_id = model.order_status_id,
                confirmed = model.confirmed,
                date_confirmed = model.date_confirmed,
                date_add = model.date_add,
                date_in_status = model.date_in_status,
                user_login = model.user_login,
                phone = model.phone,
                email = model.email,
                user_comments = model.user_comments,
                admin_comments = model.admin_comments,
                currency = model.currency,
                payment_done = model.payment_done,
                delivery_method = model.delivery_method,
                delivery_price = model.delivery_price,
                delivery_package_module = model.delivery_package_module,
                delivery_package_nr = model.delivery_package_nr,
                delivery_fullname = model.delivery_fullname,
                delivery_company = model.delivery_address,
                delivery_address = model.delivery_address,
                delivery_city = model.delivery_city,
                delivery_postcode = model.delivery_postcode,
                delivery_country_code = model.delivery_country_code,
                delivery_point_id = model.delivery_point_id,
                delivery_point_name = model.delivery_point_name,
                delivery_point_address = model.delivery_point_address,
                delivery_point_postcode = model.delivery_point_postcode,
                delivery_point_city = model.delivery_point_city,
                invoice_fullname = model.invoice_fullname,
                invoice_company = model.invoice_company,
                invoice_nip = model.invoice_nip,
                invoice_address = model.invoice_address,
                invoice_city = model.invoice_city,
                invoice_postcode = model.invoice_postcode,
                invoice_country_code = model.invoice_country_code,
                want_invoice = model.want_invoice,
                extra_field_1 = model.extra_field_1,
                extra_field_2 = model.extra_field_2,
                order_page = model.order_page,
                pick_state = model.pick_state,
                pack_state = model.pack_state,
                delivery_country = model.delivery_country,
                invoice_country = model.invoice_country,
                products = model.products.Select(p => MapProductToDto(p)).ToArray()
            };
        private Dto.Baselinker.ProductDto MapProductToDto(Product model) =>
            new Dto.Baselinker.ProductDto
            {
                storage = model.storage,
                storage_id = model.storage_id,
                order_product_id = model.order_product_id,
                product_id = model.product_id,
                variant_id = model.variant_id,
                name = model.name,
                attributes = model.attributes,
                sku = model.sku,
                ean = model.ean,
                auction_id = model.auction_id,
                price_brutto = model.price_brutto,
                tax_rate = model.tax_rate,
                quantity = model.quantity,
                weight = model.weight
            };
        private Dto.Baselinker.OrderResultDto MapOrderResultToDto(OrderResult model) =>
            new Dto.Baselinker.OrderResultDto
            {
                status = model.status,
                orders = model.orders.Select(p => MapOrderToDto(p)).ToArray()
            };
        private Dto.Baselinker.OrderInputDto MapOrderInputToDto(OrderInput model) => 
            new Dto.Baselinker.OrderInputDto
            {
                Order_id = model.Order_id,
                Date_confirmed_from = model.Date_confirmed_from,
                Date_from = model.Date_from,
                Id_from = model.Id_from,
                Get_unconfirmed_orders = model.Get_unconfirmed_orders,
                Status_id = model.Status_id,
                Filter_email = model.Filter_email
            };

        
        private Order MapOrderToModel(IOrderDto dto) =>
            new Order
            {
                order_id = dto.order_id,
                shop_order_id = dto.shop_order_id,
                external_order_id = dto.external_order_id,
                order_source = dto.order_source,
                order_source_id = dto.order_source_id,
                order_source_info = dto.order_source_info,
                order_status_id = dto.order_status_id,
                confirmed = dto.confirmed,
                date_confirmed = dto.date_confirmed,
                date_add = dto.date_add,
                date_in_status = dto.date_in_status,
                user_login = dto.user_login,
                phone = dto.phone,
                email = dto.email,
                user_comments = dto.user_comments,
                admin_comments = dto.admin_comments,
                currency = dto.currency,
                payment_done = dto.payment_done,
                delivery_method = dto.delivery_method,
                delivery_price = dto.delivery_price,
                delivery_package_module = dto.delivery_package_module,
                delivery_package_nr = dto.delivery_package_nr,
                delivery_fullname = dto.delivery_fullname,
                delivery_company = dto.delivery_address,
                delivery_address = dto.delivery_address,
                delivery_city = dto.delivery_city,
                delivery_postcode = dto.delivery_postcode,
                delivery_country_code = dto.delivery_country_code,
                delivery_point_id = dto.delivery_point_id,
                delivery_point_name = dto.delivery_point_name,
                delivery_point_address = dto.delivery_point_address,
                delivery_point_postcode = dto.delivery_point_postcode,
                delivery_point_city = dto.delivery_point_city,
                invoice_fullname = dto.invoice_fullname,
                invoice_company = dto.invoice_company,
                invoice_nip = dto.invoice_nip,
                invoice_address = dto.invoice_address,
                invoice_city = dto.invoice_city,
                invoice_postcode = dto.invoice_postcode,
                invoice_country_code = dto.invoice_country_code,
                want_invoice = dto.want_invoice,
                extra_field_1 = dto.extra_field_1,
                extra_field_2 = dto.extra_field_2,
                order_page = dto.order_page,
                pick_state = dto.pick_state,
                pack_state = dto.pack_state,
                delivery_country = dto.delivery_country,
                invoice_country = dto.invoice_country,
                products = dto.products.Select(p => MapProductToModel(p)).ToArray()
            };
        private Product MapProductToModel(IProductDto dto) =>
            new Product
            {
                storage = dto.storage,
                storage_id = dto.storage_id,
                order_product_id = dto.order_product_id,
                product_id = dto.product_id,
                variant_id = dto.variant_id,
                name = dto.name,
                attributes = dto.attributes,
                sku = dto.sku,
                ean = dto.ean,
                auction_id = dto.auction_id,
                price_brutto = dto.price_brutto,
                tax_rate = dto.tax_rate,
                quantity = dto.quantity,
                weight = dto.weight
            };
        private OrderResult MapOrderResultToModel(IOrderResultDto dto) =>
            new OrderResult
            {
                status = dto.status,
                orders = dto.orders.Select(p => MapOrderToModel(p)).ToArray()
            };
        private OrderInput MapOrderInputToModel(IOrderInputDto dto) =>
            new OrderInput
            {
                Order_id = dto.Order_id,
                Date_confirmed_from = dto.Date_confirmed_from,
                Date_from = dto.Date_from,
                Id_from = dto.Id_from,
                Get_unconfirmed_orders = dto.Get_unconfirmed_orders,
                Status_id = dto.Status_id,
                Filter_email = dto.Filter_email
            };
    }
}
