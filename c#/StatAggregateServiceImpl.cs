using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Backend
{
    /// <summary>
    /// SqliteDbManagerImpl class provides methods to get
    /// countries populations statistics as services.
    /// 
    /// </summary>
    public class StatAggregateServiceImpl : IStatAggregateService
    {
        private SqliteDbManagerImpl sqliteDbManagerImpl;

        /// <summary>
        /// Instantiates a new Stat Aggregate Service
        /// </summary>
        public StatAggregateServiceImpl()
        {
            sqliteDbManagerImpl = new SqliteDbManagerImpl();
        }

        /// <summary>
        /// The method combines the population information of countries obtained from 
        /// database and API in Dictionary, if the same country information in both 
        /// data sources information from database is given preference. 
        /// </summary>
        /// <returns>Dictionary with all the countries and its population
        /// key as country name and value as populations
        /// </returns>
        public Dictionary<string, int> GetCountryPopulations()
        {
            Dictionary<string, int> dict = sqliteDbManagerImpl.GetCountryPopulations();
            HelperServices helper = new HelperServices();

            Console.WriteLine("results from the Database class ----------------------------------");
            helper.PrintDictionary(dict);

            IStatService statServiceFromConcrete = new ConcreteStatService();

            List<Tuple<string, int>> listFromConcrete = statServiceFromConcrete.GetCountryPopulations();

            Console.WriteLine("results from the concrete class --------------------------------------");

            helper.AddPopulationsToDictionary(dict, listFromConcrete);

            Console.WriteLine("Total results and merging both lists --------------------------------------");

            Console.WriteLine("Total results and merging both lists --------------------------------------size : " + dict.Count);
            return dict;
        }
    }
}
