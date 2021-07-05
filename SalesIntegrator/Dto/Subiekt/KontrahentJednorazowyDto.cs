using InsERT;
using SalesIntegrator.Dto.Interfaces;
using SalesIntegrator.Dto.Subiekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.DTOs.Subiekt
{
    public class KontrahentJednorazowyDto : IDto
    {
        public AplikacjaDto Aplikacja { get; set; }
        public dynamic Rodzic { get; set; }
        public string ObiektNazwa { get; set; }
        public string ObiektXml { get; set; }
        public int ObiektId { get; set; }
        public dynamic Identyfikator { get; set; }
        public bool MoznaEdytowac { get; set; }
        public bool MoznaUsunac { get; set; }
        public dynamic Nazwa { get; set; }
        public dynamic NazwaPelna { get; set; }
        public dynamic Ulica { get; set; }
        public dynamic NrDomu { get; set; }
        public dynamic NrLokalu { get; set; }
        public dynamic KodPocztowy { get; set; }
        public dynamic Miejscowosc { get; set; }
        public dynamic Wojewodztwo { get; set; }
        public dynamic Panstwo { get; set; }
        public dynamic NIP { get; set; }
        public dynamic REGON { get; set; }
        public dynamic PESEL { get; set; }
        public KhTelefonyDto Telefony { get; set; }
        public KhRachunkiDto Rachunki { get; set; }
        public bool PowielPESELBezUI { get; set; }
        public bool PowielNIPBezUI { get; set; }
        public bool CzynnyPodatnikVAT { get; set; }
        public KontrahentPodatekAkcyzowyEnum PodatekAkcyzowy { get; set; }
        public KontrahentStatusAkcyzowyEnum StatusAkcyzowy { get; set; }
        public dynamic Email { get; set; }
    }
}
