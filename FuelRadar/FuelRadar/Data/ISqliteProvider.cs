using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace FuelRadar.Data
{
    public interface ISqliteProvider
    {
        SQLiteConnection GetConnection();
    }
}
