using System;
using System.Data.SQLite;

namespace Onions
{
    /// <summary>
    /// Execute Create, read, update and delete (CRUD) operations against the database.
    /// </summary>
    internal class DatabaseAccess
    {
        //Database name.
        private const string OrionServiceDatabase = "OrionsServiceDatabase";

        //Database Path.
        private static string DatabasePath = string.Concat(Environment.CurrentDirectory);

        /// <summary>
        /// Create a Connection and a Command.
        /// </summary>
        /// <param name="pSqlCmd">SQL- Command</param>
        /// <returns></returns>
        internal static SQLiteCommand fnSetConexion(string pSqlCmd)
        {
            //Connection String
            string DataSource = string.Format(@"Data Source={0}\{1}", DatabasePath, OrionServiceDatabase);

            //Create database Connection
            SQLiteConnection objCnx = new SQLiteConnection(DataSource);

            //Create database Command
            SQLiteCommand objCmd = new SQLiteCommand(pSqlCmd, objCnx);

            //Open Database Connection
            objCmd.Connection.Open();

            //Return Command
            return objCmd;
        }
    }
}