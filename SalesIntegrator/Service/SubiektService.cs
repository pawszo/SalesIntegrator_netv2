using InsERT;
using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Model;
using SalesIntegrator.Utils;
using System;
using System.Collections.Generic;
using Convert = SalesIntegrator.Utils.Convert;

using System.Reflection;
using SalesIntegrator.Service.Interface;
using SalesIntegrator.Mapper.Interface;
using System.Linq;
using SalesIntegrator.Mapper;
using SalesIntegrator.Dto.Baselinker;
using SalesIntgrator.Dto.Subiekt;
using SalesIntegrator.Dto.Subiekt;
using SalesIntegrator.DTOs.Subiekt;
using SalesIntegrator.Model.Interface;

namespace SalesIntegrator.Service
{
    public class SubiektService : IERPService, IStartable, IClosable
    {
        private Subiekt _subiekt;
        private IDictionary<string, Type> _subiektTypes;
        private readonly IDatabaseService _dbService;
        private readonly IMapper _subiektMapper;

        public SubiektService(IDatabaseService dbService, IEnumerable<IMapper> mappers)
        {
            _subiektTypes = Constants.GetSubiektTypes();
            _dbService = dbService;
            _subiektMapper = mappers.First(m => m is SubiektMapper);

        }

        

        public void Close()
        {
            if (_subiekt.Aplikacja.Zakoncz()) NonBlockingConsole.WriteLine($"Subiekt closed successfully");
        }


        private SuDokument DodajZamowienie(SuDokumentDto dto, KontrahentJednorazowy kontrahent)
        {
            SuDokument doc = _subiekt.SuDokumentyManager.DodajZK();
            string type = "SuDokument";
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "KontrahentId", kontrahent.Identyfikator);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "LiczonyOdCenBrutto", dto.LiczonyOdCenBrutto);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "Wystawil", _subiekt.OperatorNazwa);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "Uwagi", dto.Uwagi);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "Tytul", "Zamowienie od klienta");
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "DataWystawienia", dto.DataWystawienia.ToString("dd/MM/yyyy"));
            var waluta = _dbService.GetAttributeId(dto.WalutaSymbol, "wl_Symbol", "sl_Waluta", "wl_Id");
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "WalutaSymbol", waluta);
            COMHelper.SetPropertyValue<SuDokument>(doc, _subiektTypes[type], "NumerOryginalny", dto.NumerOryginalny);
            SuPozycje pozycje = doc.Pozycje;
            foreach (var prod in dto.Pozycje.Elements.Cast<SuPozycjaDto>())
            {
                string pozycjaType = "SuPozycja";
                int vatId = _dbService.GetAttributeId($"{prod.VatProcent}", "vat_Stawka", "sl_StawkaVAT", "vat_Id");
                SuPozycja usluga = pozycje.DodajUslugeJednorazowa();
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "IloscJm", (float)prod.IloscJm);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "UslJednNazwa", prod.UslJednNazwa);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "VatId", vatId);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaNettoPrzedRabatem", prod.CenaNettoPrzedRabatem);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaNettoPoRabacie", prod.CenaNettoPoRabacie);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaBruttoPrzedRabatem", prod.CenaBruttoPrzedRabatem);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "CenaBruttoPoRabacie", prod.CenaBruttoPoRabacie);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscBruttoPrzedRabatem", prod.WartoscBruttoPrzedRabatem);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscBruttoPoRabacie", prod.WartoscBruttoPoRabacie);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscNettoPrzedRabatem", prod.WartoscNettoPrzedRabatem);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "WartoscNettoPoRabacie", prod.WartoscNettoPoRabacie);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "Jm",prod.Jm);
                COMHelper.SetPropertyValue<SuPozycja>(usluga, _subiektTypes[pozycjaType], "RabatProcent", 0);
                NonBlockingConsole.WriteLine($"Added product {prod.TowarNazwa}");
            }
            
            doc.Zapisz();
            NonBlockingConsole.WriteLine($"Saved order for client {kontrahent.Identyfikator}");
            return doc;
        }
        /// <summary>
        /// Tworzy i uzupelnia dane kontrahenta
        /// </summary>
        /// <param name="order">Zamowienie z baselinkera</param>
        /// <returns>Utworzony kontrahent</returns>
        private KontrahentJednorazowy DodajKontrahenta(KontrahentJednorazowyDto dto)
        {
            //var orderDto = _subiektMapper.
            KontrahentJednorazowy kontrJedn = _subiekt.KontrahenciManager.DodajKontrahentaJednorazowego();
            string type = "KontrahentJednorazowy";
            
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NazwaPelna", dto.NazwaPelna);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Nazwa", dto.Nazwa);
            var phoneEnum = dto.Telefony.Elements.Cast<KhTelefonDto>().GetEnumerator(); 
            while(phoneEnum.MoveNext()) kontrJedn.Telefony.Dodaj(phoneEnum.Current.Numer);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Email", dto.Email);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NIP", dto.NIP);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Ulica", dto.Ulica);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NrDomu", dto.NrDomu);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "NrLokalu", dto.NrLokalu);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "KodPocztowy", dto.KodPocztowy);
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Miejscowosc", dto.Miejscowosc);
            int countryId = _dbService.GetAttributeId(dto.Panstwo, "pa_Nazwa", "sl_Panstwo", "pa_Id");
            COMHelper.SetPropertyValue<KontrahentJednorazowy>(kontrJedn, _subiektTypes[type], "Panstwo", countryId);
            kontrJedn.Zapisz();
            NonBlockingConsole.WriteLine($"Saved client {kontrJedn.Identyfikator}");

            return kontrJedn;
        }
        public void Start(IDBConnectionModel dbUser, ILoginModel erpLogin)
        {
            GT gt = new GT()
            {
                Produkt = ProduktEnum.gtaProduktSubiekt,
                Serwer = dbUser.ServerName,
                Baza = dbUser.DatabaseName,
                Autentykacja = AutentykacjaEnum.gtaAutentykacjaMieszana,
                Uzytkownik = dbUser.Username,
                UzytkownikHaslo = dbUser.Password,
                Operator = erpLogin.Username,
                OperatorHaslo = erpLogin.Password
            };

            _subiekt = (Subiekt)gt.Uruchom(
                (Int32)UruchomDopasujEnum.gtaUruchomDopasuj,
                (Int32)UruchomEnum.gtaUruchomNieArchiwizujPrzyZamykaniu);
            _subiekt.Okno.Widoczne = true;
            _dbService.Initialize(_subiekt);
            NonBlockingConsole.WriteLine("Subiekt GT properly started");
        }

        public void RegisterOrders(IEnumerable<IModel> orders)
        {
            foreach(var order in orders)
            {
                var dto = _subiektMapper.MapToDto(order) as SuDokumentDto;
                var kontrahent = DodajKontrahenta(dto.Kontrahent);
                DodajZamowienie(dto, kontrahent);
                NonBlockingConsole.WriteLine($"Order {dto.Numer} registered successfully.");
            }
            NonBlockingConsole.WriteLine("JOB FINISHED :)");
        }
    }
}
