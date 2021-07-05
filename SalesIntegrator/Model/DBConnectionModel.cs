using SalesIntegrator.Dto.Interfaces;
using SalesIntegrator.Model.Interface;
using System.Collections.Generic;

namespace SalesIntegrator.Model
{
    public class DBConnectionModel : IDBConnectionModel
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }



        public void SetFields(IDictionary<string, string> fields)
        {
            ServerName = fields["serverName"];
            DatabaseName = fields["dbName"];
            Username = fields["username"];
            Password = fields["password"];
        }
        public void SetFields(IModel model)
        {
            var dbModel = model as IDBConnectionModel;
            ServerName = dbModel.ServerName;
            DatabaseName = dbModel.DatabaseName;
            Username = dbModel.Username;
            Password = dbModel.Password;
        }
    }
}
