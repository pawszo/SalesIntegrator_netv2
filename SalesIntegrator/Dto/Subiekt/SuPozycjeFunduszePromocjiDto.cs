using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Subiekt
{
    public class SuPozycjeFunduszePromocjiDto : ISubiektCollection
    {
        public int Liczba { get; set; }
        public AplikacjaDto Aplikacja { get; set; }
        public int ObiektId { get; set; }
        public IEnumerable<IDto> Elements { get; set; }
    }
}
