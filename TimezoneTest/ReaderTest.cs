using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timezone;

namespace TimezoneTest
{
    [TestClass]
    public class ReaderTest
    {

        public const string PATH_TO_FILE = @"..\..\";

        [TestMethod]
        public void FileExists()
        {
            string fileName = "Timezone.txt";
            string path = Path.Combine(Environment.CurrentDirectory, PATH_TO_FILE, fileName);
            Reader reader = new Reader();
            Assert.IsTrue(reader.fileExists(path));
        }

    }
}
