using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Backend
{
    class IStatServiceImpl : IStatService
    {
        public List<Tuple<string, int>> GetCountryPopulations()
        {
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            SQLiteConnection sQLiteConnection = null;

            try
            {
                sQLiteConnection = new SQLiteConnection("Data Source=citystatecountry.db;Version=3;FailIfMissing=True");
                sQLiteConnection.Open();
                String sql = "select country.countryname as country, sum(city.population) as population from country country inner join state state on state.countryId = country.countryId inner join city city on city.stateId = state.stateId group by countryname";
                SQLiteCommand command = new SQLiteCommand(sql, sQLiteConnection);
                SQLiteDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    //Console.WriteLine("Country :" + sdr["country"] + " Population :" + sdr["population"]);
                    list.Add(new Tuple<string, int>((sdr["country"]).ToString(), Convert.ToInt32(sdr["population"])));

                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                sQLiteConnection.Close();
            }

            return list;
        }

        public Task<List<Tuple<string, int>>> GetCountryPopulationsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
