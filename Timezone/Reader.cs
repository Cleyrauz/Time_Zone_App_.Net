using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    public class Reader : IReader, IDisposable
    {

        public List<Tuple<string, string>> Read(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\", fileName);
            List<Tuple<string, string>> lReturn = null;
            if (fileExists(path))
            {
                string[] fileParts = splitFileByLine(path);
                lReturn = loadListOfTimes(fileParts);
            }

            return lReturn;
        }

        public List<Tuple<string, string>> loadListOfTimes(string[] fileParts)
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();
            foreach (string part in fileParts)
            {
                string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Tuple<string, string> timeZone = new Tuple<string, string>(sLineParts.First(), sLineParts.Last());

                lReturn.Add(timeZone);
            }

            return lReturn;
        }

        public string[] splitFileByLine(string path)
        {
            return File.ReadAllText(path).Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        public bool fileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(fileName);
            }

            return File.Exists(fileName);
        }

        public void Dispose()
        {
        }
    }
}
