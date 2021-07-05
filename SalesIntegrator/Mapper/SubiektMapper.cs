using SalesIntegrator.Dto.Interfaces;
using SalesIntegrator.Dto.Subiekt;
using SalesIntegrator.DTOs.Subiekt;
using SalesIntegrator.Mapper.Interface;
using SalesIntegrator.Model;
using SalesIntegrator.Model.Interface;
using SalesIntgrator.Dto.Subiekt;
using System;
using Convert = SalesIntegrator.Utils.Convert;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Mapper
{
    public class SubiektMapper : IMapper
    {
        public IDto MapToDto(IModel model)
        {
            switch (model)
            {
                case Order o:
                    return MapToSuDokumentDto(o);
                default: return null;

            }
        }

        public IModel MapToModel(IDto dto)
        {
            switch (dto)
            {
                // here add new mappers if needed
                default: return null;

            }
        }

        private SuDokumentDto MapToSuDokumentDto(Order model) =>
            new SuDokumentDto
            {
                DataOtrzymania = Convert.UnixTimeStampToDate(model.date_add).Date,
                DataWystawienia = DateTime.Now.Date,
                DoDokumentuDataWystawienia = Convert.UnixTimeStampToDate(model.date_confirmed).Date,
                DoDokumentuId = model.order_id,
                DoDokumentuNumerPelny = model.order_id,
                Kontrahent = new KontrahentJednorazowyDto
                {
                    
                },
                KwotaDoZaplaty = model.products.Select(p => p.price_brutto*p.quantity).Sum(),
                LiczonyOdCenBrutto = true,
                Pozycje = new SuPozycjeDto
                {
                    Elements = model.products.Select(p => MapToSuPozycjaDto(p)).ToList(),
                    Liczba = model.products.Count()
                },
                Tytul = string.Concat("OrderNo_", model.shop_order_id, " ", model.user_login),
                WalutaSymbol = model.currency
            };
        private AplikacjaDto MapToAplikacjaDto(Order model) =>
            new AplikacjaDto
            {
                
            };
        private GridEdycyjnyDto MapToGridEdycyjnyDto(Order model) =>
            new GridEdycyjnyDto
            {
                //todo
            };
        private KontrahentJednorazowyDto MapToKontrahentJednorazowyDto(Order model) =>
            new KontrahentJednorazowyDto
            {
                //todo
            };
        private PrzedplatyDto MapToPrzedplatyDto(Order model) =>
            new PrzedplatyDto
            {
                //todo
            };
        private SuBrakiDto MapToSuBrakiDto(Order model) =>
            new SuBrakiDto
            {
                //todo
            };
        private SuDokPromocjeDto MapToSuDokPromocjeDto(Order model) =>
            new SuDokPromocjeDto
            {
                //todo
            };
        private SuPozycjaDto MapToSuPozycjaDto(Product model) =>
            new SuPozycjaDto
            {
                TowarNazwa = model.name,
                TowarOpis = model.ean,
                IloscJm = model.quantity,
                Jm = model.sku,
                CenaBruttoPrzedRabatem = model.price_brutto,
                CenaBruttoPoRabacie = model.price_brutto,
                WartoscBruttoPrzedRabatem = model.price_brutto*model.quantity,
                WartoscBruttoPoRabacie = model.price_brutto * model.quantity,
                CenaNettoPrzedRabatem = Convert.GetNettoPrice(model.price_brutto, model.tax_rate),
                CenaNettoPoRabacie = Convert.GetNettoPrice(model.price_brutto, model.tax_rate),
                WartoscNettoPrzedRabatem = Convert.GetNettoPrice(model.price_brutto, model.tax_rate) * (float)model.quantity,
                WartoscNettoPoRabacie = Convert.GetNettoPrice(model.price_brutto, model.tax_rate) * (float)model.quantity,
                WartoscVatPoRabacie = Convert.GetVATPrice(Convert.GetNettoPrice(model.price_brutto, model.tax_rate), model.tax_rate),
                VatProcent = model.tax_rate,
                Opis = string.Concat(model.name, "\n", model.variant_id, "\n", model.ean),
                UslugaJednorazowa = true, //MAY CHANGE
            };
        private SuPozycjeFunduszePromocjiDto MapToSuPozycjeFunduszePromocjiDto(Order model) =>
            new SuPozycjeFunduszePromocjiDto
            {
                //todo
            };
        private SuPozycjeNiezgodnosciFMDto MapToSuPozycjeNiezgodnosciFMDto(Order model) =>
            new SuPozycjeNiezgodnosciFMDto
            {
                //todo
            };
        private SuPozycjeVatDto MapToSuPozycjeVatDto(Order model) =>
            new SuPozycjeVatDto
            {
                //todo
            };
        private WiadomoscDto MapToWiadomoscDto(Order model) =>
            new WiadomoscDto
            {
                //todo
            };

    }
}
