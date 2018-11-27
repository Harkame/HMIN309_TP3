using SQLite;
using HMIN309_TP3.Models;

namespace HMIN309_TP3
{
    public class DatabaseHelper
    {
        private SQLiteConnection sqliteConnection;

        public DatabaseHelper()
        {
            sqliteConnection = new SQLiteConnection(Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.Personal),"EventDatabase.db3"););

            sqliteConnection.CreateTable<Event>();
        }

        public void InsertEvent(Event eventToInsert)
        {
            sqliteConnection.Insert(eventToInsert);
        }

        public Event[] getAllEvents()
        {
            return sqliteConnection.Table<Event>().ToArray();
        }
    }
}

