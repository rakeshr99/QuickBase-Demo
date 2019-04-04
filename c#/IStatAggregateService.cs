using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    /// <summary>
    /// IStatAggregateService interface provides methods
    /// using which we can get information of countries
    /// and its population.
    /// </summary>
    public interface IStatAggregateService
    {
        /// <summary>
        /// The method combines the population information of countries obtained from 
        /// database and API in Dictionary, if the same country information in both 
        /// data sources information from database is given preference. 
        /// </summary>
        /// <returns>Dictionary with all the countries and its population
        /// key as country name and value as populations
        /// </returns>
        Dictionary<string, int> GetCountryPopulations();

        /// <summary>
        /// The method combines the population information of countries obtained from 
        /// database and API in Dictionary, if the same country information in both 
        /// data sources information from database is given preference. 
        /// </summary>
        /// <returns>Dictionary with all the countries and its population
        /// key as country name and value as populations
        /// </returns>
        int getSpecificCountryPopulation(string countryName);
    }
}
