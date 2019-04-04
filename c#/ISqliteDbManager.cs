using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Backend
{
    /// <summary>
    /// ISqliteDbManager interface provides methods to
    /// be used during database operations
    /// </summary>
    public interface ISqliteDbManager
    {
        /// <summary>
        /// This method establishes a connection to the database
        /// </summary>
        /// <returns>SQLiteConnection to the database</returns>
        SQLiteConnection getConnection();

        /// <summary>
        /// This method gets the population of a specific country
        /// </summary>
        /// <param name="countryName">Country Name</param>
        /// <returns>Integer specifying </returns>
        int getSpecificCountryPopulation(string countryName);

        /// <summary>
        /// This method validates if country name is valid string
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns>boolean value validating if it is a valid string</returns>
        bool isValidCountryName(string countryName);
    }
}
