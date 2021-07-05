using InsERT;
using SalesIntegrator.Dto.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Subiekt
{
    public class SuPozycjaDto : ISubiektDto
    {
        public AplikacjaDto Aplikacja { get; set; }
        public dynamic Rodzic { get; set; }
        public string ObiektNazwa { get; set; }
        public string ObiektXml { get; set; }
        public int ObiektId { get; set; }
        public dynamic Lp { get; set; }
        public dynamic TowarId { get; set; }
        public dynamic TowarRodzaj { get; set; }
        public dynamic TowarSymbol { get; set; }
        public dynamic TowarSymbolUDostawcy { get; set; }
        public dynamic TowarNazwa { get; set; }
        public dynamic TowarPKWiU { get; set; }
        public dynamic TowarOpis { get; set; }
        public dynamic Ilosc { get; set; }
        public dynamic IloscJm { get; set; }
        public dynamic Jm { get; set; }
        public dynamic CenaMagazynowa { get; set; }
        public dynamic CenaNettoPrzedRabatem { get; set; }
        public dynamic CenaBruttoPrzedRabatem { get; set; }
        public dynamic RabatProcent { get; set; }
        public dynamic VatProcent { get; set; }
        public dynamic VatId { get; set; }
        public dynamic CenaNettoPoRabacie { get; set; }
        public dynamic CenaBruttoPoRabacie { get; set; }
        public dynamic WartoscMagazynowa { get; set; }
        public dynamic WartoscNettoPrzedRabatem { get; set; }
        public dynamic WartoscBruttoPrzedRabatem { get; set; }
        public dynamic WartoscNettoPoRabacie { get; set; }
        public dynamic WartoscVatPoRabacie { get; set; }
        public dynamic WartoscBruttoPoRabacie { get; set; }
        public dynamic Opis { get; set; }
        public dynamic MagazynId { get; set; }
        public dynamic Termin { get; set; }
        public dynamic Id { get; set; }
        public dynamic KodDostawy { get; set; }
        public bool UslugaJednorazowa { get; set; }
        public dynamic UslJednNazwa { get; set; }
        public dynamic UslJednPKWiU { get; set; }
        public dynamic KategoriaId { get; set; }
        public dynamic CenaNabycia { get; set; }
        public dynamic WartNabycia { get; set; }
        public dynamic TowarFlagaNazwa { get; set; }
        public dynamic TowarFlagaKomentarz { get; set; }
        public bool PodlegaAkcyzie { get; set; }
        public dynamic KwotaAkcyzy { get; set; }
        public dynamic WartoscAkcyzy { get; set; }
        public dynamic DoId { get; set; }
        public dynamic DostepnaIlosc { get; set; }
        public dynamic SyncId { get; set; }
        public dynamic TowarKodCN { get; set; }
        public bool PonizejMarzyMin { get; set; }
        public PozycjaTypPromocjiEnum PozycjaTypPromocji { get; set; }
        public bool PozycjaTylkoDoOdczytu { get; set; }
    }
}