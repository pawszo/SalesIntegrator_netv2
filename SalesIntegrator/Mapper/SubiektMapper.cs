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
using SalesIntegrator.Utils;

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
                Kontrahent = MapToKontrahentJednorazowyDto(model),
                KwotaDoZaplaty = model.products.Select(p => p.price_brutto*p.quantity).Sum(),
                LiczonyOdCenBrutto = true,
                Pozycje = new SuPozycjeDto
                {
                    Elements = model.products.Select(p => MapToSuPozycjaDto(p)).ToList(),
                    Liczba = model.products.Count()
                },
                Tytul = string.Concat("OrderNo_", model.shop_order_id, " ", model.user_login),
                WalutaSymbol = model.currency,
                Uwagi = model.user_comments,
                NumerOryginalny = model.external_order_id               
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
        private KontrahentJednorazowyDto MapToKontrahentJednorazowyDto(Order model)
        {

            string ulica, nrDomu, nrLokalu, kodPocztowy, miejscowosc, panstwo;
            if (!string.IsNullOrWhiteSpace(model.invoice_address))
            {
                ulica = RegexHelper.GetStreetName(model.invoice_address);
                nrDomu = RegexHelper.GetBuildingNumber(model.invoice_address);
                nrLokalu = RegexHelper.GetApartmentNumber(model.invoice_address);
                kodPocztowy = model.invoice_postcode;
                miejscowosc = model.invoice_city;
                panstwo = model.invoice_country;
            }
            else
            {
                ulica = RegexHelper.GetStreetName(model.delivery_address);
                nrDomu = RegexHelper.GetBuildingNumber(model.delivery_address);
                nrLokalu = RegexHelper.GetApartmentNumber(model.delivery_address);
                kodPocztowy = model.delivery_postcode;
                miejscowosc = model.delivery_city;
                panstwo = model.delivery_country;
            }
            return new KontrahentJednorazowyDto
            {
                NazwaPelna = $"{model.invoice_fullname}\n{model.invoice_company}",
                Nazwa = model.user_login,
                Email = model.email,
                NIP = model.invoice_nip,
                Ulica = ulica,
                NrDomu = nrDomu,
                NrLokalu = nrLokalu,
                KodPocztowy = kodPocztowy,
                Miejscowosc = miejscowosc,
                Panstwo = panstwo,
                Telefony = MapToKhTelefonyDto(model) 
            };
        }
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
                UslJednNazwa = model.name,
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
                UslugaJednorazowa = true //MAY CHANGE
                
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
        private KhTelefonyDto MapToKhTelefonyDto(Order model) =>
            new KhTelefonyDto
            {
                Liczba = 1,
                Elements = new KhTelefonDto[] { new KhTelefonDto
                {
                    Numer = model.phone
                }
                }
            };

    }
}
