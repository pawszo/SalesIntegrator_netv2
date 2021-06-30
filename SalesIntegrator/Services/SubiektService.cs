using InsERT;
using SalesIntegrator.Controllers;
using SalesIntegrator.Models;
using SalesIntegrator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convert = SalesIntegrator.Utils.Convert;
using System.Data;
using SalesIntegrator.Services;
using System.Runtime.InteropServices;
using MDFLib;
using System.Diagnostics;
using System.Dynamic;
using Newtonsoft.Json;
using System.Reflection;

namespace SalesIntegrator.Services
{
    public class SubiektService : ISubiektService
    {
        private Subiekt _subiekt;
        private IEnumerable<Order> _orders;
        private IDictionary<string, Type> _subiektTypes;
        private DatabaseService _dbService;

        public SubiektService()
        {
            _subiektTypes = GetSubiektTypes();
        }

        private IDictionary<string, Type> GetSubiektTypes()
        {
            var insertAssembly = Assembly.LoadFile(@"C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Interop.InsERT4\v4.0_1.0.0.0__a59bfa3a209beb60\Interop.InsERT4.dll");
            var adoAssembly = Assembly.LoadFile(@"C:\WINDOWS\assembly\GAC\ADODB\7.0.3300.0__b03f5f7f11d50a3a\ADODB.dll");
            var types = new Dictionary<string, Type>();
            types.Add("KontrahentJednorazowy", insertAssembly.GetType("InsERT.KontrahentJednorazowy"));
            types.Add("SuDokument", insertAssembly.GetType("InsERT.SuDokument"));
            types.Add("Towar", insertAssembly.GetType("InsERT.Towar"));
            types.Add("SuPozycjeVat", insertAssembly.GetType("InsERT.SuPozycjeVat"));
            types.Add("Baza", insertAssembly.GetType("InsERT.BazaClass"));
            types.Add("Connection", adoAssembly.GetType("ADODB.Connection"));
            types.Add("Subiekt", insertAssembly.GetType("InsERT.Subiekt"));
            types.Add("Recordset", adoAssembly.GetType("ADODB.Recordset"));
            types.Add("Fields", adoAssembly.GetType("ADODB.Fields"));
            types.Add("Field", adoAssembly.GetType("ADODB.Field"));
            types.Add("_Recordset", adoAssembly.GetType("ADODB._Recordset"));
            types.Add("InternalFields", adoAssembly.GetType("ADODB.InternalFields"));
            types.Add("SuPozycje", insertAssembly.GetType("InsERT.SuPozycje"));
            types.Add("SuPozycja", insertAssembly.GetType("InsERT.SuPozycja"));
            return types;
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
                var nettoPrice = SalesIntegrator.Utils.Convert.GetNettoPrice(prod.price_brutto, prod.tax_rate);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaNettoPrzedRabatem", nettoPrice);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaNettoPoRabacie", nettoPrice);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaBruttoPrzedRabatem", nettoPrice);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaBruttoPoRabacie", nettoPrice);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscBruttoPrzedRabatem", prod.price_brutto * (float)prod.quantity);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscBruttoPoRabacie", prod.price_brutto * (float)prod.quantity);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscNettoPrzedRabatem", nettoPrice * (float)prod.quantity);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscNettoPoRabacie", nettoPrice * (float)prod.quantity);
                var vatValue = SalesIntegrator.Utils.Convert.GetVATPrice(nettoPrice * (float)prod.quantity, prod.tax_rate);
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
            _dbService = new DatabaseService(_subiekt, GetSubiektTypes());

        }

        public void ProcessOrders()
        {
            foreach(var order in _orders)
            {
                EnterData(order);
                NonBlockingConsole.WriteLine($"Order {order.order_id} registered successfully.");
            }
        }

        public void PassOrders(IEnumerable<Order> newOrders)
        {
            _orders = newOrders;
        }
    }
}
