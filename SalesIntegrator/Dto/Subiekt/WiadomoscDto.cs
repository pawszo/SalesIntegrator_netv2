using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Subiekt
{
    public class WiadomoscDto : IDto
    {
        public dynamic Tytul { get; set; }
        public dynamic Opis { get; set; }
    }
}
