using System;
using System.IO;

using SQLite;
using Xamarin.Forms;

using FuelRadar.Data;
using FuelRadar.Droid.Data;

[assembly: Dependency(typeof(AndroidSqliteProvider))]
namespace FuelRadar.Droid.Data
{
    /// <summary>
    /// The android implementation of the sqlite database interface
    /// </summary>
    public class AndroidSqliteProvider : ISqliteProvider
    {
        private const String DB_NAME = "FuelRadar.db3";

        public SQLiteConnection GetConnection()
        {
            String documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return new SQLiteConnection(Path.Combine(documentsPath, DB_NAME));
        }
    }
}
