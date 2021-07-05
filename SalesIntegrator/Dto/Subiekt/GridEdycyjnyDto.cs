using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Subiekt
{
    public class GridEdycyjnyDto : IDto
    {
        public AplikacjaDto Aplikacja { get; set; }
        public object Rodzic { get; set; }
        public string ObiektNazwa { get; set; }
        public string ObiektXml { get; set; }
        public int ObiektId { get; set; }
        public int BiezacyWiersz { get; set; }
        public object ZaznaczoneWiersze { get; set; }
        public int LiczbaWierszy { get; set; }
        public dynamic Identyfikator { get; set; }
        public string NazwaGrida { get; set; }
        public string BiezacaKolumna { get; set; }
    }
}