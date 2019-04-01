using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Test
{
    /// <summary>
    /// Test class for country populations
    /// </summary>
    [TestClass]
    public class CountryPopulationTest
    {
        [TestMethod]
        public void TestPrintDictionary()
        {
            //Arrange with all the variables needed in the test
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("India", 1182105000);
            dict.Add("United Kingdom", 62026962);
            dict.Add("Chile", 17094270);
            dict.Add("Mali", 15370000);
            dict.Add("Greece", 11305118);
            dict.Add("Armenia", 3249482);
            dict.Add("Slovenia", 2046976);

            //Act
            Backend.HelperServices helper = new HelperServices();

            helper.PrintDictionary(dict);
        }

        [TestMethod]
        public void TestAddPopulationsToDictionary()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            List<Tuple<string, int>> list = new List<Tuple<string, int>>
            {
                Tuple.Create("India",1182105000)
            };

            Backend.HelperServices helper = new HelperServices();
            helper.AddPopulationsToDictionary(dict, list);

            foreach (KeyValuePair<string, int> entry in dict)
            {
                Assert.AreEqual(entry.Key, "India");
                Assert.AreEqual(entry.Value, 1182105000);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNullDictionary()
        {
            Dictionary<string, int> dict = null;
            List<Tuple<string, int>> list = null;

            Backend.HelperServices helper = new HelperServices();
            helper.AddPopulationsToDictionary(dict, list);
        }

        [TestMethod]
        public void TestSameCountryFromAPIAndDatabaseDifferentRepresentation()
        {
            //database entry
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("U.S.A.", 311976362);

            //API entry
            List<Tuple<string, int>> list = new List<Tuple<string, int>>
            {
                Tuple.Create("United States of America",1182105000)
            };

            Backend.HelperServices helper = new HelperServices();
            dict = helper.AddPopulationsToDictionary(dict, list);

            foreach (KeyValuePair<string, int> entry in dict)
            {
                Assert.AreEqual(entry.Key, "U.S.A.");
                Assert.AreEqual(entry.Value, 311976362);
            }

        }

        [TestMethod]
        public void TestSameCountryFromAPIAndDatabase()
        {
            //database entry
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("India", 1210854977);

            //API entry
            List<Tuple<string, int>> list = new List<Tuple<string, int>>
            {
                Tuple.Create("India",1182105000)
            };

            Backend.HelperServices helper = new HelperServices();
            dict = helper.AddPopulationsToDictionary(dict, list);

            foreach (KeyValuePair<string, int> entry in dict)
            {
                Assert.AreEqual(entry.Key, "India");
                Assert.AreEqual(entry.Value, 1210854977);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNullAPIList()
        {
            //database entry
            Dictionary<string, int> dict = new Dictionary<string, int>();

            //API entry
            List<Tuple<string, int>> list = null;

            Backend.HelperServices helper = new HelperServices();
            dict = helper.AddPopulationsToDictionary(dict, list);


        }


        [TestMethod]
        public void TestDbConnectionFromDB()
        {
            ISqliteDbManager manager = new SqliteDbManagerImpl();

            SQLiteConnection sQLiteConnection = manager.getConnection();


        }
    }
}
