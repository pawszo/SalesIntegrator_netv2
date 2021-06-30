namespace SalesIntegrator.Models
{
    public class DBConnectionModel
    {
        public string ServerName { get; private set; }
        public string DatabaseName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public DBConnectionModel(string serverName, string dbName, string username, string password)
        {
            ServerName = serverName;
            DatabaseName = dbName;
            Username = username;
            Password = password;
        }
    }
}
