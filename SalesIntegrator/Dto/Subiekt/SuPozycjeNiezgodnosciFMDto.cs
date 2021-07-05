using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Subiekt
{
    public class SuPozycjeNiezgodnosciFMDto : ISubiektDto
    {
        public AplikacjaDto Aplikacja { get; set; }
        public int ObiektId { get; set; }
    }
}
