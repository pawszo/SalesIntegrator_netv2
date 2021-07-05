using SalesIntegrator.Dto.Interfaces;
using SalesIntegrator.Dto.Subiekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Interface
{
    public interface ISubiektDto : IDto
    {
        AplikacjaDto Aplikacja { get; set; }
        int ObiektId { get; set; }

    }
}
