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
            const string USA = "United States of America";
            Console.WriteLine("Started");
            Console.WriteLine("Getting DB Connection...");

            IDbManager db = new SqliteDbManager();
            DbConnection conn = db.getConnection();
            Console.WriteLine("hello world");
            if(conn == null)
            {
                Console.WriteLine("Failed to get connection");
            }

            IStatService statServiceFromDb = new IStatServiceImpl();
            List<Tuple<string, int>> listFromDb = statServiceFromDb.GetCountryPopulations();
            HelperServices helper = new HelperServices();

            Console.WriteLine("results from the Database class ----------------------------------");
            Dictionary<string, int> dict = new Dictionary<string, int>();

            dict = helper.AddPopulationsToDictionary(dict, listFromDb);

            IStatService statServiceFromConcrete = new ConcreteStatService();

            List<Tuple<string, int>> listFromConcrete = statServiceFromConcrete.GetCountryPopulations();

          
            Console.WriteLine("results from the concrete class --------------------------------------");

            helper.AddPopulationsToDictionary(dict, listFromConcrete);

            Console.WriteLine("Total results and merging both lists --------------------------------------");
            helper.PrintDictionary(dict);

            Console.WriteLine("Total results and merging both lists --------------------------------------size : " + dict.Count);

            Console.ReadKey();

        }
    }
}
