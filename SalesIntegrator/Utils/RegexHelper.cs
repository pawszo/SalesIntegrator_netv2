using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesIntegrator.Utils
{
    public static class RegexHelper
    {
        public static string GetStreetName(string streetWithNumber)
        {
            Regex rgx = new Regex(@"[\D]*");
            if (rgx.IsMatch(streetWithNumber))
            {
                return rgx.Matches(streetWithNumber)[0].Value;
            }
            else return streetWithNumber;
        }

        public static string GetBuildingNumber(string streetWithNumber)
        {
            Regex rgx = new Regex(@"[\d]+\w?");
            if (rgx.IsMatch(streetWithNumber))
            {
                return rgx.Matches(streetWithNumber)[0].Value;
            }
            else return string.Empty;
        }
        public static string GetApartmentNumber(string streetWithNumber)
        {
            Regex rgx = new Regex(@"[\d]+\w?");
            if (rgx.Matches(streetWithNumber).Count > 1)
            {
                return rgx.Matches(streetWithNumber)[1].Value;
            }
            else return string.Empty;
        }

    }
}
