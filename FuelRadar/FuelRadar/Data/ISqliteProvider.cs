using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace FuelRadar.Data
{
    /// <summary>
    /// A sqlite database interface to implemented on each platform
    /// </summary>
    public interface ISqliteProvider
    {
        SQLiteConnection GetConnection();
    }
}
