using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Managers
{
    internal static class BFHelper
    {
        internal static DateTime ConvertUtcToTimeZone(DateTime dt, string tmzName)
        {
            TimeZoneInfo tmz = TimeZoneInfo.FindSystemTimeZoneById(tmzName);
            TimeSpan tmz_diff = tmz.BaseUtcOffset;
            DateTime dtconv;
            dtconv = dt.Add(tmz_diff);

            return dtconv;
        }

        internal static DateTime ConvertTimeZoneToUTC(DateTime dt, string tmzName)
        {
            TimeZoneInfo tmz = TimeZoneInfo.FindSystemTimeZoneById(tmzName);
            TimeSpan tmz_diff = tmz.BaseUtcOffset;
            DateTime dtconv;
            dtconv = dt.Subtract(tmz_diff);

            return dtconv;
        }

        
    }
}
