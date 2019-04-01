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
    }
}
