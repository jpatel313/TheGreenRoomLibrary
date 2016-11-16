using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace UnitTestGRL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateFile()
        {
            
            string filelocation = "../../test.txt";
            File.Create(filelocation);
            
            Assert.AreEqual(File.Exists(filelocation), true);
        }
        [TestMethod]
        public void TestWriteToFile()
        {
            string filelocation = "../../test.txt";
            StreamWriter writer = new StreamWriter(filelocation);
            List<String> testList = new List<string> { "blah", "blah blah", "boo" };
            foreach (string word in testList)
            {
                writer.Write(word);
            }
            writer.Close();

            string[] readBlahs = File.ReadAllLines(filelocation);
            
            writer.Dispose();
            Assert.AreEqual(readBlahs.Length, 3);
        }
    }
}
