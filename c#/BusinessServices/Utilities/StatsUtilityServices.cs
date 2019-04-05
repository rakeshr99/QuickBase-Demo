using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    /// <summary>
    /// HelperServices class consists of helper methods for 
    /// population services.
    /// </summary>
    public class StatsUtilityServices
    {
        /// <summary>
        /// This method prints countries and its population
        /// </summary>
        /// <param name="dict">Dictionary contains countries and its population information</param>
        public void PrintDictionary(Dictionary<string, int> dict)
        {
            foreach (KeyValuePair<string, int> entry in dict)
            {
                Console.WriteLine("Country :" + entry.Key + " Population :" + entry.Value);
            }
        }

        /// <summary>
        /// This method iterates through the countries information list retrieved from API
        /// and adds the details to the dictionary. It also validates if the country names are
        /// valid by checking against a dictionary which will have all valid country names
        /// from the database.
        /// 
        /// </summary>
        /// <param name="dict">resultant dictionary with all country names and values</param>
        /// <param name="list">list retrieved from the API</param>
        /// <returns>Dictionary with all countries mapped to its population</returns>
        public Dictionary<string, int> AddPopulationsToDictionary(Dictionary<string, int> dict, List<Tuple<string, int>> list)
        {
            string country = "";
            Dictionary<string, string> validCountryNames  =  ValidCountryNames.getValidCountryNames();
            foreach (Tuple<string, int> tuple in list)
            {
                country = tuple.Item1;
                if (validCountryNames.ContainsKey(tuple.Item1))
                {
                    country = validCountryNames[country];
                }
                if (!dict.ContainsKey(country))
                {
                    dict.Add(country, tuple.Item2);
                }

            }

            return dict;
        }
    }
}
