using SalesIntegrator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Service.Interface
{
    public interface IStartable
    {
        void Start(IDBConnectionModel dBConnection, ILoginModel erpLogin);
    }
}
