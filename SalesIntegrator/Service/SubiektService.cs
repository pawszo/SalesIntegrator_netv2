using InsERT;
using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Model;
using SalesIntegrator.Utils;
using System;
using System.Collections.Generic;
using Convert = SalesIntegrator.Utils.Convert;

using System.Reflection;
using SalesIntegrator.Service.Interface;

namespace SalesIntegrator.Service
{
    public class SubiektService : ISubiektService
    {
        private Subiekt _subiekt;
        private IDictionary<string, Type> _subiektTypes;
        private readonly IDatabaseService _dbService;

        public SubiektService(IDatabaseService dbService)
        {
            _subiektTypes = Constants.GetSubiektTypes();
            _dbService = dbService;

        }

        

        public void CloseSubiekt()
        {
            if (_subiekt.Aplikacja.Zakoncz()) NonBlockingConsole.WriteLine($"Subiekt closed successfully");
        }

        public void EnterData(Order order)
        {
            var kontrahent = DodajKontrahenta(order);
            DodajZamowienie(order, kontrahent);
        }

        public SuDokument DodajZamowienie(Order order, KontrahentJednorazowy kontrahent)
        {
            SuDokument doc = _subiekt.SuDokumentyManager.DodajZK();
            string type = "SuDokument";
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "KontrahentId", kontrahent.Identyfikator);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "LiczonyOdCenBrutto", true);

            SuPozycje pozycje = doc.Pozycje;
            foreach (var prod in order.products)
            {
                string pozycjaType = "SuPozycja";
                SuPozycja usluga = pozycje.DodajUslugeJednorazowa();
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "IloscJm", (float)prod.quantity);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "UslJednNazwa", prod.name);

                int vatId = _dbService.GetAttributeId($"{prod.tax_rate}", "vat_Stawka", "sl_StawkaVAT", "vat_Id");
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "VatId", vatId);
                var nettoPrice = Convert.GetNettoPrice(prod.price_brutto, prod.tax_rate);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaNettoPrzedRabatem", nettoPrice);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaNettoPoRabacie", nettoPrice);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaBruttoPrzedRabatem", nettoPrice);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaBruttoPoRabacie", nettoPrice);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscBruttoPrzedRabatem", prod.price_brutto * (float)prod.quantity);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscBruttoPoRabacie", prod.price_brutto * (float)prod.quantity);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscNettoPrzedRabatem", nettoPrice * (float)prod.quantity);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscNettoPoRabacie", nettoPrice * (float)prod.quantity);
                var vatValue = Convert.GetVATPrice(nettoPrice * (float)prod.quantity, prod.tax_rate);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "Jm", prod.sku);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "RabatProcent", 0);
                NonBlockingConsole.WriteLine($"Added product {prod.name}");
            }
            var wystawil = _subiekt.OperatorNazwa;
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "Wystawil", wystawil);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "Uwagi", order.user_comments);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "Tytul", "Zamowienie od klienta");
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "DataWystawienia", DateTime.Now.ToString("dd/MM/yyyy"));
            var waluta = _dbService.GetAttributeId(order.currency, "wl_Symbol", "sl_Waluta", "wl_Id");
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "WalutaSymbol", waluta);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "NumerOryginalny", order.external_order_id);

            doc.Zapisz();
            NonBlockingConsole.WriteLine($"Saved order for client {kontrahent.Identyfikator}");
            return doc;
        }
        /// <summary>
        /// Tworzy i uzupelnia dane kontrahenta
        /// </summary>
        /// <param name="order">Zamowienie z baselinkera</param>
        /// <returns>Utworzony kontrahent</returns>
        public KontrahentJednorazowy DodajKontrahenta(Order order)
        {
            KontrahentJednorazowy kontrJedn = _subiekt.KontrahenciManager.DodajKontrahentaJednorazowego();
            string type = "KontrahentJednorazowy";

            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NazwaPelna", $"{order.invoice_fullname}\n{order.invoice_company}");
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Nazwa", order.user_login);
            kontrJedn.Telefony.Dodaj(order.phone);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Email", order.email);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NIP", order.invoice_nip);
            if (!string.IsNullOrWhiteSpace(order.invoice_address))
            {
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Ulica", RegexHelper.GetStreetName(order.invoice_address));
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NrDomu", RegexHelper.GetBuildingNumber(order.invoice_address));
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NrLokalu", RegexHelper.GetApartmentNumber(order.invoice_address));
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "KodPocztowy", order.invoice_postcode);
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Miejscowosc", order.invoice_city);
                int id = _dbService.GetAttributeId(order.invoice_country, "pa_Nazwa", "sl_Panstwo", "pa_Id");
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Panstwo", id);

            }
            else
            {
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Ulica", RegexHelper.GetStreetName(order.delivery_address));
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NrDomu", RegexHelper.GetBuildingNumber(order.delivery_address));
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NrLokalu", RegexHelper.GetApartmentNumber(order.delivery_address));
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "KodPocztowy", order.delivery_postcode);
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Miejscowosc", order.delivery_city);
                int id = _dbService.GetAttributeId(order.delivery_country, "pa_Nazwa", "sl_Panstwo", "pa_Id");
                COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Panstwo", id);
            }
            kontrJedn.Zapisz();
            NonBlockingConsole.WriteLine($"Saved client {kontrJedn.Identyfikator}");

            return kontrJedn;
        }
        public void StartSubiekt(DBConnectionModel dbUser, InsertUserModel insertUser)
        {
            GT gt = new GT()
            {
                Produkt = ProduktEnum.gtaProduktSubiekt,
                Serwer = dbUser.ServerName,
                Baza = dbUser.DatabaseName,
                Autentykacja = AutentykacjaEnum.gtaAutentykacjaMieszana,
                Uzytkownik = dbUser.Username,
                UzytkownikHaslo = dbUser.Password,
                Operator = insertUser.Username,
                OperatorHaslo = insertUser.Password
            };

            _subiekt = (Subiekt)gt.Uruchom(
                (Int32)UruchomDopasujEnum.gtaUruchomDopasuj,
                (Int32)UruchomEnum.gtaUruchomNieArchiwizujPrzyZamykaniu);
            _subiekt.Okno.Widoczne = true;
            _dbService.Initialize(_subiekt);

        }

        public void ProcessOrders(IEnumerable<Order> orders)
        {
            foreach(var order in orders)
            {
                EnterData(order);
                NonBlockingConsole.WriteLine($"Order {order.order_id} registered successfully.");
            }
        }

    }
}
