using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Started");
            Console.WriteLine("Getting DB Connection...");

            IDbManager db = new SqliteDbManager();
            DbConnection conn = db.getConnection();
            Console.WriteLine("hello world");
            if(conn == null)
            {
                Console.WriteLine("Failed to get connection");
            }

            StatsUtilityServices helperServices = new StatsUtilityServices();
            IStatAggregateService statAggregateService = new StatAggregateServiceImpl();
            //Retrieving countries and its populations
            Dictionary<string, int> populationResults = statAggregateService.GetCountryPopulations();
            helperServices.PrintDictionary(populationResults);

            Console.ReadKey();
        }
    }
}
