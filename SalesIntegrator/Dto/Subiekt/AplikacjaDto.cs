using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Subiekt
{
    public class AplikacjaDto : IDto
    {
        public AplikacjaDto Aplikacja { get; set; }
        public dynamic Rodzic { get; set; }
        public string ObiektNazwa { get; set; }
        public string ObiektXml { get; set; }
        public int ObiektId { get; set; }
        public object Baza { get; set; }
        public string PodmiotNazwa { get; set; }
        public string OperatorNazwa { get; set; }
        public bool Zajeta { get; set; }
        public object Okno { get; set; }
        public string Wersja { get; set; }
    }
}
