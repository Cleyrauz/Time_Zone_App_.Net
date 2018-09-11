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
            DateTime timeToConvert = Convert.ToDateTime(time);
            DateTime convertedTime = TimeZoneInfo.ConvertTime(timeToConvert, getTimeZoneFromCity(timezone));
            string convertedTimeFormated = convertedTime.ToString("HH:mm");
            System.Diagnostics.Debug.WriteLine("The time in the UK is " + time + " and the time in " + timezone + " is " + convertedTimeFormated);
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
