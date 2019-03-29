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

            Console.WriteLine("results from the Database class ----------------------------------");
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (Tuple<string, int> tuple in listFromDb)
            {
                Console.WriteLine("Country :" + tuple.Item1 + " Population :" + tuple.Item2);
                dict.Add(tuple.Item1, tuple.Item2);
            }

            IStatService statServiceFromConcrete = new ConcreteStatService();

            List<Tuple<string, int>> listFromConcrete = statServiceFromConcrete.GetCountryPopulations();

          
            Console.WriteLine("results from the concrete class --------------------------------------");

            foreach (Tuple<string, int> tuple in listFromConcrete)
            {
                Console.WriteLine("Country :" + tuple.Item1 + " Population :" + tuple.Item2);

                if (tuple.Item1.Equals(USA))
                {
                    continue;
                }
                if (!dict.ContainsKey(tuple.Item1))
                {
                    dict.Add(tuple.Item1, tuple.Item2);
                }
                
            }

            Console.WriteLine("Total results and merging both lists --------------------------------------");
            foreach(KeyValuePair<string, int> entry in dict)
            {
                Console.WriteLine("Country :" + entry.Key + " Population :" + entry.Value);
            }

            Console.WriteLine("Total results and merging both lists --------------------------------------size : " + dict.Count);

            Console.ReadKey();

        }
    }
}
