using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    /// <summary>
    /// ValidCountryNames consists of methods that provides 
    /// valid country names which could be represented by different names.
    /// </summary>
    public sealed class ValidCountryNames
    {
        /// <summary>
        /// This method is used to maintain a consistent string representation
        /// of a country throughout the project. The valid string representation
        /// of the country is country name coming from the database. So is there
        /// other string representations used then it maps those represenations to
        /// the country name in the database.
        /// </summary>
        /// <returns>Dictionary with names representing a country to the actual
        /// name in the database</returns>
        public static Dictionary<string, string> getValidCountryNames()
        {
            Dictionary<string, string> countries = new Dictionary<string, string>();
            countries.Add("United States of America", "U.S.A.");

            return countries;
        }
    }
}
