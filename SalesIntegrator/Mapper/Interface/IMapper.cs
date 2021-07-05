using SalesIntegrator.Model.Interface;
using SalesIntegrator.Dto.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIntegrator.Dto.Interfaces;

namespace SalesIntegrator.Mapper.Interface
{
    public interface IMapper
    {

        IDto MapToDto(IModel model);
        IModel MapToModel(IDto dto);
    }
}
