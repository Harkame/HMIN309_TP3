using SQLite;
using HMIN309_TP3.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HMIN309_TP3
{
    public static class DatabaseHelper
    {
        private static SQLiteConnection sqliteConnection = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EventDatabase.db3"));

        static DatabaseHelper()
        {
            sqliteConnection.DropTable<Event>();
            sqliteConnection.CreateTable<Event>();
        }

        public static void InsertEvent(Event eventToInsert)
        {
            sqliteConnection.Insert(eventToInsert);
        }

        public static Event[] getAllEvents()
        {
            return sqliteConnection.Table<Event>().ToArray();
        }
    }
}

