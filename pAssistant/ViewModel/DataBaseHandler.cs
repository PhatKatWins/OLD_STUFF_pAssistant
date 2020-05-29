using pAssistant.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace pAssistant.ViewModel
{
    class DataBaseHandler
    {
        private static readonly string dataBaseFilePath = Path.Combine(Environment.CurrentDirectory, "entriesDb.paf");

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(dataBaseFilePath))
            {
                conn.CreateTable<Entry>();
                int afectedRows = conn.Insert(item);
                if(afectedRows >= 1) { result = true; }
            }

            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(dataBaseFilePath))
            {
                conn.CreateTable<Entry>();
                int afectedRows = conn.Update(item);
                if (afectedRows >= 1) { result = true; }
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(dataBaseFilePath))
            {
                conn.CreateTable<Entry>();
                int afectedRows = conn.Delete(item);
                if (afectedRows >= 1) { result = true; }
            }

            return result;
        }

        public static List<Entry> ReadTable()
        {
            List<Entry> resultSet;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(dataBaseFilePath))
            {
                conn.CreateTable<Entry>();
                resultSet = conn.Table<Entry>().ToList();
            }

            return resultSet;
        }
    }
}
