using System;
using System.IO;

using SQLite;
using Xamarin.Forms;

using FuelRadar.Data;


[assembly: Dependency(typeof(AndroidSqliteProvider))]
public class AndroidSqliteProvider : ISqliteProvider
{
    private const String DB_NAME = "FuelRadar.db3";

    public SQLiteConnection GetConnection()
    {
        String documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        return new SQLiteConnection(Path.Combine(documentsPath, DB_NAME));
    }
}