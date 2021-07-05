using InsERT;
using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Dto.Interfaces;
using SalesIntegrator.Dto.Subiekt;
using SalesIntegrator.DTOs.Subiekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntgrator.Dto.Subiekt
{
    public class SuDokumentDto : ISubiektDto
    {
        public AplikacjaDto Aplikacja { get; set; }
        public string ObiektNazwa { get; set; }
        public string ObiektXml { get; set; }
        public int ObiektId { get; set; }
        public dynamic Identyfikator { get; set; }
        public Nullable<bool> MoznaEdytowac { get; set; }
        public Nullable<bool> MoznaUsunac { get; set; }
        public WiadomoscDto Wiadomosc { get; set; }
        public SuBrakiDto PozycjeBrakujace { get; set; }
        public SuPozycjeDto Pozycje { get; set; }
        public SuPozycjeVatDto PozycjeVat { get; set; }
        public dynamic Numer { get; set; }
        public dynamic NumerRozszerzenie { get; set; }
        public dynamic NumerPelny { get; set; }
        public dynamic NumerOryginalny { get; set; }
        public dynamic DoDokumentuId { get; set; }
        public dynamic DoDokumentuNumerPelny { get; set; }
        public dynamic DoDokumentuDataWystawienia { get; set; }
        public dynamic MiejsceWystawienia { get; set; }
        public dynamic DataWystawienia { get; set; }
        public dynamic DataOtrzymania { get; set; }
        public dynamic DataMagazynowa { get; set; }
        public dynamic MagazynOdbiorczyId { get; set; }
        public dynamic MagazynNadawczyId { get; set; }
        public dynamic KasaFiskalnaId { get; set; }
        public KontrahentJednorazowyDto Kontrahent { get; set; }
        public dynamic OdbiorcaId { get; set; }
        public dynamic LiczonyOdCenNetto { get; set; }
        public dynamic LiczonyOdCenBrutto { get; set; }
        public dynamic WalutaSymbol { get; set; }
        public dynamic WalutaKurs { get; set; }
        public dynamic PoziomCenyId { get; set; }
        public dynamic NarzutCeny { get; set; }
        public dynamic KursCeny { get; set; }
        public dynamic RabatProcent { get; set; }
        public dynamic PlatnoscGotowkaKwota { get; set; }
        public dynamic PlatnoscGotowkaReszta { get; set; }
        public dynamic PlatnoscKartaId { get; set; }
        public dynamic PlatnoscKartaKwota { get; set; }
        public dynamic PlatnoscRatyId { get; set; }
        public dynamic PlatnoscRatyKwota { get; set; }
        public dynamic PlatnoscKredytId { get; set; }
        public dynamic PlatnoscKredytTermin { get; set; }
        public dynamic PlatnoscKredytKwota { get; set; }
        public dynamic KwotaDoZaplaty { get; set; }
        public dynamic Wystawil { get; set; }
        public dynamic Odebral { get; set; }
        public dynamic PersonelId { get; set; }
        public dynamic KategoriaId { get; set; }
        public dynamic Tytul { get; set; }
        public dynamic Podtytul { get; set; }
        public dynamic Uwagi { get; set; }
        public dynamic WartoscBrutto { get; set; }
        public dynamic WartoscVat { get; set; }
        public dynamic WartoscNetto { get; set; }
        public dynamic WartoscMagazynowa { get; set; }
        public dynamic WartoscOpakowanWydanych { get; set; }
        public dynamic WartoscOpakowanZwroconych { get; set; }
        public dynamic WartoscTowaruBrutto { get; set; }
        public dynamic WartoscTowaruNetto { get; set; }
        public dynamic WartoscUslugBrutto { get; set; }
        public dynamic WartoscUslugNetto { get; set; }
        public dynamic TransakcjaRodzajOperacjiVat { get; set; }
        public dynamic TransakcjaKod { get; set; }
        public dynamic StatusDokumentu { get; set; }
        public dynamic StatusFiskalny { get; set; }
        public dynamic StatusKsiegowy { get; set; }
        public dynamic SkutekMagazynowy { get; set; }
        public dynamic Rezerwacja { get; set; }
        public dynamic VatLiczonyAutomatycznie { get; set; }
        public dynamic TerminRealizacji { get; set; }
        public dynamic Rozliczony { get; set; }
        public Nullable<bool> AutoPrzeliczanie { get; set; }
        public Nullable<int> Typ { get; set; }
        public Nullable<int> Podtyp { get; set; }
        public StatusKsiegowyDokumentuEnum StatusKsiegowyDokumentu { get; set; }
        public Nullable<int> WalutaLiczbaJednostek { get; set; }
        public Nullable<int> LiczbaJednostekCeny { get; set; }
        public dynamic KasaId { get; set; }
        public decimal PozostaleZaliczki { get; set; }
        public string FlagaNazwa { get; set; }
        public string FlagaKomentarz { get; set; }
        public dynamic PlatnoscPrzelewKwota { get; set; }
        public Nullable<int> DokumentDefiniowalnyId { get; set; }
        public dynamic ZaliczkaKwota { get; set; }
        public dynamic DrukarkaFiskalnaId { get; set; }
        public Nullable<bool> RejestrujNaUF { get; set; }
        public Nullable<bool> WartosciInneNizWyliczone { get; set; }
        public PrzedplatyDto Przedplaty { get; set; }
        public dynamic WalutaDataKursu { get; set; }
        public dynamic WalutaTypKursu { get; set; }
        public dynamic WalutaTabelaBanku { get; set; }
        public dynamic KursCenyDataKursu { get; set; }
        public dynamic KursCenyTypKursu { get; set; }
        public dynamic KursCenyTabelaBanku { get; set; }
        public Nullable<int>[] DokumentyZrodlowe { get; set; }
        public dynamic ZlecenieId { get; set; }
        public Nullable<bool> NaliczajFunduszePromocji { get; set; }
        public SuPozycjeFunduszePromocjiDto PozycjeFunduszePromocji { get; set; }
        public Nullable<bool> WstrzymajOdswiezanieListyPozycji { get; set; }
        public dynamic InnaDataPlatnosciKasa { get; set; }
        public dynamic InnaDataPlatnosciBank { get; set; }
        public Nullable<bool> VatMarza { get; set; }
        public DokumentDostawyEnum ObslugaDokumentuDostawy { get; set; }
        public dynamic PodstawaPrawnaZwolnieniaZAkcyzy { get; set; }
        public dynamic DokDostawyNumer { get; set; }
        public dynamic DokDostawyNumerRozszerzenie { get; set; }
        public dynamic DokDostawyNumerPelny { get; set; }
        public SuPozycjeNiezgodnosciFMDto PozycjeNiezgodnosciFM { get; set; }
        public RodzajProceduryMarzyEnum RodzajProceduryMarzy { get; set; }
        public Nullable<bool> FakturaUproszczona { get; set; }
        public dynamic DataZakonczeniaDostawy { get; set; }
        public Nullable<bool> MetodaKasowa { get; set; }
        public dynamic DataSprzedazy { get; set; }
        public RodzajZwrotuDetalEnum RodzajZwrotuDetal { get; set; }
        public Nullable<int> TypNrIdentNabywcy { get; set; }
        public dynamic NrIdentNabywcy { get; set; }
        public dynamic PrzedplatyGotowkowe { get; set; }
        public dynamic PrzedplatyBankowe { get; set; }
        public dynamic BankRachunekPodmiotuId { get; set; }
        public dynamic BankRachunekKontrahentaId { get; set; }
        public Nullable<bool> BankOperacjaGotowkowa { get; set; }
        public dynamic VenderoId { get; set; }
        public dynamic VenderoSymbol { get; set; }
        public dynamic VenderoData { get; set; }
        public dynamic SelloId { get; set; }
        public dynamic SelloSymbol { get; set; }
        public dynamic SelloData { get; set; }
        public dynamic UwagiExt { get; set; }
        public StatusZamowieniaVenderoEnum VenderoStatus { get; set; }
        public Nullable<bool> PominAsortymentPowiazany { set; get; }
        public dynamic WydanieKatId { get; set; }
        public dynamic PrzyjecieKatId { get; set; }
        public Nullable<int> AdresDostawyId { get; set; }
        public Nullable<bool> CesjaPlatnosciNaOdbiorce { get; set; }
        public Nullable<bool> DokumentFiskalnyDlaPodatnikaVat { get; set; }
        public dynamic BankKatId { get; set; }
        public dynamic KasaKatId { get; set; }
        public Nullable<bool> Autodyspozycje { get; set; }
        public SuDokPromocjeDto SuDokPromocje { get; set; }
        public string SzczegolyOstatniegoBledu { get; set; }
        public string OstatniKomunikatKontrahenta { get; set; }
        public string OstatniKomunikatTowaru { get; set; }
        public dynamic TerminalPlatnTransId { get; set; }
        public dynamic PodzielonaPlatnosc { get; set; }
        public Nullable<bool> PrzepiszPozycjePA { get; set; }
        public dynamic WartoscVatPP { get; set; }
        public SuDokumentIdNabywcyTypEnum IdentyfikatorNabywcyTyp { get; set; }
        public dynamic IdentyfikatorNabywcy { get; set; }
        public TrybObslugiPromocjiEnum TrybObslugiPromocji { get; set; }
        public StanNaliczeniaPromocjiEnum StanNaliczeniaPromocji { get; set; }
        public Nullable<bool> MoznaSprawdzicPromocje { get; set; }
        public Nullable<bool> MoznaWycofacPromocje { get; set; }
        public Nullable<bool> MoznaPrzeniescPromocje { get; set; }
        public KontrolaRezerwacjiTowaruEnum KontrolaRezerwacjiTowaru { get; set; }
        public GridEdycyjnyDto PozycjeGrid { get; set; }
        public dynamic WSTOPanstwoRozpoczeciaWysylkiId { get; set; }
        public dynamic WSTOPanstwoKonsumentaId { get; set; }
        public string WSTOInformacjeDodatkowe { get; set; }
    }
}