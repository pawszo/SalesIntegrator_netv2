using System;
using System.Collections.Generic;
using System.Globalization;

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

    }
}
