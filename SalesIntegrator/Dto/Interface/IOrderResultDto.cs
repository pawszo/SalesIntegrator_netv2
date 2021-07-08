using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Interface
{
    
    public interface IOrderResultDto : IDto
    {
        string status { get; set; }

        IOrderDto[] orders { get; set; }
    }
}
