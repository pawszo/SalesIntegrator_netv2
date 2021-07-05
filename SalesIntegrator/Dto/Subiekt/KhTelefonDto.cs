using SalesIntegrator.Dto.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Subiekt
{
    public class KhTelefonDto : ISubiektDto
    {
        public AplikacjaDto Aplikacja { get; set; }
        public int ObiektId { get; set; }
        public string Numer { get; set; }
        public string Nazwa { get; set; }
    }
}
