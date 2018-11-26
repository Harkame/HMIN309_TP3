using SQLite;
using HMIN309_TP3.Models;

namespace HMIN309_TP3
{
    public static class DatabaseHelper
    {
        private static SQLiteConnection sqliteConnection = new SQLiteConnection("EventDatabase.db");

        public static void Initialize()
        {
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

