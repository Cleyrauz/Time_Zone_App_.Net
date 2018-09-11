﻿using System;
using System.Collections.Generic;
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNullOrEmpty_ThrowArgumentNullException()
        {
            Reader reader = new Reader();
            reader.fileExists("");
        }

        [TestMethod]
        public void CanSplitFileByLine()
        {
            string fileName = "Timezone.txt";
            string path = Path.Combine(Environment.CurrentDirectory, PATH_TO_FILE, fileName);
            Reader reader = new Reader();
            string[] actual = reader.splitFileByLine(path);

            Assert.AreEqual(8, actual.Length);
        }

        [TestMethod]
        public void CanLoadTimeZoneList()
        {
            Reader reader = new Reader();
            string[] timesFromFile = { "09:30 Amsterdam", "17:29 Minsk", "23:03 Samoa" };
            List<Tuple<string, string>> expectedList = new System.Collections.Generic.List<Tuple<string, string>>();
            expectedList.Add(new Tuple<string, string>("09:30", "Amsterdam"));
            expectedList.Add(new Tuple<string, string>("17:29", "Minsk"));
            expectedList.Add(new Tuple<string, string>("23:03", "Samoa"));

            List<Tuple<string, string>> actual = reader.loadListOfTimes(timesFromFile);

            CollectionAssert.AreEqual(expectedList, actual);
        }

    }
}
