using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Dto.Interfaces;
using SalesIntegrator.Dto.Subiekt;
using System.Collections.Generic;

namespace SalesIntegrator.DTOs.Subiekt
{
    public class KhRachunkiDto : ISubiektCollection
    {
        public AplikacjaDto Aplikacja { get; set; }
        public dynamic Rodzic { get; set; }
        public string ObiektNazwa { get; set; }
        public string ObiektXml { get; set; }
        public int Liczba { get; set; }
        public int ObiektId { get; set; }
        public IEnumerable<IDto> Elements { get; set; }
    }
}