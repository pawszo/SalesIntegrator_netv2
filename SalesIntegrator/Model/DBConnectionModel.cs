namespace SalesIntegrator.Model
{
    public class DBConnectionModel
    {
        public string ServerName { get; private set; }
        public string DatabaseName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }



        public void SetFields(string serverName, string dbName, string username, string password)
        {
            ServerName = serverName;
            DatabaseName = dbName;
            Username = username;
            Password = password;
        }
        public void SetFields(DBConnectionModel model)
        {
            ServerName = model.ServerName;
            DatabaseName = model.DatabaseName;
            Username = model.Username;
            Password = model.Password;
        }

    }
}
