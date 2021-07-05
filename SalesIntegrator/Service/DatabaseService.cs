using InsERT;
using SalesIntegrator.Service.Interface;
using SalesIntegrator.Utils;
using System;
using System.Collections.Generic;

namespace SalesIntegrator.Service
{
    public class DatabaseService : IDatabaseService
    {
        private Subiekt _subiekt;
        private ADODB.Connection _connection;
        private IDictionary<string, Type> _types;

        public DatabaseService()
        {
            _types = Constants.GetSubiektTypes();
        }
        public void Initialize(Subiekt subiekt)
        {
            _subiekt = subiekt;
            _connection = _subiekt.Baza.Polaczenie;
        }

        public int GetAttributeId(string columnValue,string columnName ,string tableName, string idColumnName)
        {
            object recs;
            int id = (int)SlownikEnum.gtaBrak;

            ADODB.Recordset rs = new ADODB.Recordset();


            string qry = string.Format($"SELECT * FROM {tableName} WHERE {columnName} = '{columnValue}';");

            rs = _connection.Execute(qry, out recs, 0);

            for (; !rs.EOF; rs.MoveNext())
            {
                var fields = COMHelper.GetPropertyValue<ADODB._Recordset>(rs, _types["_Recordset"], "Fields") as ADODB.Fields;
                var value = fields[idColumnName];
                var intValue = COMHelper.GetPropertyValue<ADODB.Field>(value, _types["Field"], "Value");
                id = (int)intValue;


            }
            return id;
        }



        
    }
}
