using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace SalesIntegrator.Utils
{
    public static class Constants
    {
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public static readonly CultureInfo CULTURE = CultureInfo.CurrentCulture;
        public const string BASELINKER_URI = @"https://api.baselinker.com/connector.php";
        public const string GET_ORDERS_METHOD = "getOrders";
        public const int WS_SYSMENU = 0x80000;
        public const int DB_CONN_TIMEOUT = 3;
        public const bool SUBIEKT_WINDOW_VISIBLE = true;

        public const string OPTIONAL_PLACEHOLDER = "optional";
        public const string PASSWORD_PLACEHOLDER = "Password";
        public const string INSERTUSER_PLACEHOLDER = "User (i.e. Szef)";
        public const string DBUSER_PLACEHOLDER = "Username (i.e. sa)";
        public const string SERVER_PLACEHOLDER = "Server (i.e. (local)\\\\INSERTGT)";
        public const string DB_PLACEHOLDER = "Database (i.e. TestSubiekt1)";
        public const int CONSOLE_HIDDEN = 0;
        public const int CONSOLE_DISPLAY = 5;

        public static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static IDictionary<string, Type> GetSubiektTypes()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string insertAssemblyPath = Path.Combine(assemblyFolder, "Interop.InsERT4.dll");
            string adoAssemblyPath = Path.Combine(assemblyFolder, "ADODB.dll");
            var insertAssembly = Assembly.LoadFile(insertAssemblyPath);
            var adoAssembly = Assembly.LoadFile(adoAssemblyPath);
            var types = new Dictionary<string, Type>();
            types.Add("KontrahentJednorazowy", insertAssembly.GetType("InsERT.KontrahentJednorazowy"));
            types.Add("SuDokument", insertAssembly.GetType("InsERT.SuDokument"));
            types.Add("Towar", insertAssembly.GetType("InsERT.Towar"));
            types.Add("SuPozycjeVat", insertAssembly.GetType("InsERT.SuPozycjeVat"));
            types.Add("Baza", insertAssembly.GetType("InsERT.BazaClass"));
            types.Add("Connection", adoAssembly.GetType("ADODB.Connection"));
            types.Add("Subiekt", insertAssembly.GetType("InsERT.Subiekt"));
            types.Add("Recordset", adoAssembly.GetType("ADODB.Recordset"));
            types.Add("Fields", adoAssembly.GetType("ADODB.Fields"));
            types.Add("Field", adoAssembly.GetType("ADODB.Field"));
            types.Add("_Recordset", adoAssembly.GetType("ADODB._Recordset"));
            types.Add("InternalFields", adoAssembly.GetType("ADODB.InternalFields"));
            types.Add("SuPozycje", insertAssembly.GetType("InsERT.SuPozycje"));
            types.Add("SuPozycja", insertAssembly.GetType("InsERT.SuPozycja"));
            return types;
        }

    }
}
