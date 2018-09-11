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
        public void FileDoesExists()
        {
            string fileName = "Timezone.txt";
            string path = Path.Combine(Environment.CurrentDirectory, PATH_TO_FILE, fileName);
            Reader reader = new Reader();
            Assert.IsTrue(reader.fileExists(path));
        }

        [TestMethod]
        public void FileDoesNotExists()
        {
            string fileName = "Badname.txt";
            string path = Path.Combine(Environment.CurrentDirectory, PATH_TO_FILE, fileName);
            Reader reader = new Reader();
            Assert.IsFalse(reader.fileExists(path));
        }

    }
}
