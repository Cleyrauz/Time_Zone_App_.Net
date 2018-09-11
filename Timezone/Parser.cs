using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    public class Parser : IParser
    {
        public const string LOCAL_CITY_NAME = "London";

        public void DisplayTime(string time, string timezone)
        {
            DateTime timeToConvert = Convert.ToDateTime(time);
           
            try {
                DateTime convertedTime = ConvertTimeFromTimeZone(timeToConvert, LOCAL_CITY_NAME, timezone);
                string convertedTimeFormated = convertedTime.ToString("HH:mm");
                System.Diagnostics.Debug.WriteLine("The time in the UK is " + time + " and the time in " + timezone + " is " + convertedTimeFormated);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("The city: "+ timezone +" doesn't match any Time Zone information");
            }
        }

        public DateTime ConvertTimeFromTimeZone(DateTime timeToConvert, string localCity, string cityFromFile)
        {
            return  TimeZoneInfo.ConvertTime(timeToConvert, GetTimeZoneFromCity(localCity), GetTimeZoneFromCity(cityFromFile));
        }

        public TimeZoneInfo GetTimeZoneFromCity(string cityName)
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
