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
            sqliteConnection.CreateTable<Event>();
        }

        public static void InsertEvent(Event eventToInsert)
        {
            RemoveOldEvents();

            sqliteConnection.Insert(eventToInsert);
        }

        public static void deleteEvent(Event eventToDelete)
        {
            RemoveOldEvents();

            sqliteConnection.Delete(eventToDelete);
        }

        public static Event[] GetAllEvents()
        {
            RemoveOldEvents();

            return sqliteConnection.Table<Event>().ToArray();
        }

        public static Event[] GetAllEventsByName(string eventName)
        {
            RemoveOldEvents();

            return sqliteConnection.Table<Event>().Where(x => x.Name.ToLower().Contains(eventName.ToLower())).ToArray();
        }

        private static void RemoveOldEvents()
        {
            sqliteConnection.Execute("DELETE FROM Events WHERE date < " + DateTime.Now.Ticks + "; ");
        }
    }
}

