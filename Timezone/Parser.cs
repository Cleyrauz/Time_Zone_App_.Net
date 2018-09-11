using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Parser : IParser
    {
        public void DisplayTime(string time, string timezone)
        {
            DateTime dateTime = Convert.ToDateTime(time);
            DateTime convertedTime = TimeZoneInfo.ConvertTime(dateTime, getTimeZoneFromCity(timezone));
            System.Diagnostics.Debug.WriteLine("The time in the UK is " + time + " and the time in " + timezone + " is " + convertedTime);
        }

        public TimeZoneInfo getTimeZoneFromCity(string cityName)
        {
            List<TimeZoneInfo> tzList = TimeZoneInfo.GetSystemTimeZones().ToList();
            foreach (TimeZoneInfo timeZone in tzList)
            {
                if (timeZone.DisplayName.Contains(cityName))
                {
                    return timeZone;
                }
            }
            return null;
        }
    }
}
