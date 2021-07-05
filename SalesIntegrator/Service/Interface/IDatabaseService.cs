using InsERT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Service.Interface
{
    public interface IDatabaseService
    {
        int GetAttributeId(string columnValue, string columnName, string tableName, string idColumnName);
        void Initialize(Subiekt subiekt);
    }
}
