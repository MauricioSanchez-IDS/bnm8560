﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    public class TestDataAltas
    {
        private static string testFileName;

        public static string getPath()
        {
            string path;

            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\C430\\Test\\TarjetaCorporativa\\";

            return path;
        }


        public static bool ExistTest()
        {
            bool r = false;

            System.IO.FileInfo fi = new System.IO.DirectoryInfo(getPath()).GetFiles("*_active.json").FirstOrDefault();

            if (fi.Exists)
            {
                testFileName = fi.FullName;
                r = fi.Exists;
            }

            return r;
        }


        public static Dictionary<string, string> getTestData()
        {
            Dictionary<string, string> testData;

            var json = System.IO.File.ReadAllText(testFileName);

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            testData = jss.Deserialize<Dictionary<string, string>>(json);

            return testData;
        }

        public static bool MoveTestFile() { 
            string dDirectory = testFileName.Replace("Test","Read");
            System.IO.File.Move(testFileName, dDirectory);

            return true;
        }
    }
}