﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            Parser timeZoneParser = new Parser();
            using (Reader fileReader = new Reader())
            {
                List<Tuple<string, string>> lTimes = fileReader.Read("Timezone.txt");
                if (lTimes != null)
                {
                    foreach (Tuple<string, string> time in lTimes)
                    {
                        timeZoneParser.DisplayTime(time.Item1, time.Item2);
                    }
                }
            }
        }
    }
}
