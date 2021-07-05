using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Interface
{
    public interface ISubiektCollection : ISubiektDto
    {
        int Liczba { get; set; }
        IEnumerable<IDto> Elements { get; set; }
    }
}
