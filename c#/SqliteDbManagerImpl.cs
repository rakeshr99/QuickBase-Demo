﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    /// <summary>
    /// SqliteDbManagerImpl class provides methods to get
    /// countries populations statistics from the database
    /// 
    /// </summary>
    public class SqliteDbManagerImpl : ISqliteDbManager
    {
        /// <summary>
        /// This method establishes a connection to the database
        /// </summary>
        /// <returns>SQLiteConnection to the database</returns>
        public SQLiteConnection getConnection()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(DBConstants.CONNECTION_STRING);
                return connection.OpenAndReturn();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// This method connects to the database and retrieves all the countries
        /// and its populations ands the results to dictionary
        /// </summary>
        /// <returns>Dictionary with all the countries and its populations from the database</returns>
        public Dictionary<string, int> GetCountryPopulations()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            SQLiteConnection sQLiteConnection = null;
            try
            {
                sQLiteConnection = getConnection();
                SQLiteCommand command = new SQLiteCommand(DBConstants.GET_ALL_COUNTRY_POPULATION, sQLiteConnection);
                SQLiteDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    dict.Add((sdr[DBConstants.COUNTRY]).ToString(), Convert.ToInt32(sdr[DBConstants.POPULATION]));

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

            return dict;
        }
    }
}
