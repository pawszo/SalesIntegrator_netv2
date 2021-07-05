using SalesIntegrator.Model;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Utils
{
    public static class Convert
    {
        /// <summary>
        /// Parse string in format dd-MM-yyyy to DateTime
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns>DateTime object</returns>
        public static int DateStringToUnixTimestamp(string dateString)
        {
            var date = DateTime.ParseExact(dateString, Constants.DATE_FORMAT, Constants.CULTURE);
            return (Int32)(date.Subtract(Constants.EPOCH)).TotalSeconds;
        }

        public static string DBConnModelToConnString(DBConnectionModel dbModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Data Source={dbModel.ServerName};");
            sb.Append($"Initial Catalog={dbModel.DatabaseName};");
            sb.Append("Integrated Security=true;");
            return sb.ToString();
        }

        public static string UnixTimeStampToDateString(int unixTimeStamp)
        {
            DateTime dt = Constants.EPOCH;
            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();
            return (dt.ToString(Constants.DATE_FORMAT));
        }
        public static DateTime UnixTimeStampToDate(int unixTimeStamp)
        {
            DateTime dt = Constants.EPOCH;
            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();
            return dt.Date;
        }

        public static float GetNettoPrice(float bruttoPrice, int taxRate)
        {
            float rate = float.Parse($"1.{taxRate}", CultureInfo.InvariantCulture);
            return bruttoPrice / (float)rate;
        }

        public static float GetVATPrice(float nettoPrice, int taxRate)
        {
            float rate = float.Parse($"1.{taxRate}", CultureInfo.InvariantCulture);
            return nettoPrice * (float)rate;
        }
    }
}
