using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{   
    /// <summary>
    /// This class consists of all the constants required for
    /// database operations along with sql queries.
    /// </summary>
    public static class DBConstants
    {
        public const string CONNECTION_STRING = "Data Source=citystatecountry.db;Version=3;FailIfMissing=True";
        public const string GET_ALL_COUNTRY_POPULATION = "select country.countryname as country, sum(city.population) as population " +
            "from country country inner join state state on state.countryId = country.countryId " +
            "inner join city city on city.stateId = state.stateId group by countryname";
        public const string GET_SPECIFIC_COUNTRY_POPULATION = "select country.countryname as country, sum(city.population) as population " +
            "from country country inner join state state on state.countryId = country.countryId " +
            "inner join city city on city.stateId = state.stateId " +
            "where country.countryname = @param";
        public const string COUNTRY = "country";
        public const string POPULATION = "population";
    }
}
