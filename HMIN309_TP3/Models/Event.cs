﻿using SQLite;

namespace HMIN309_TP3.Models
{
    [Table("Events")]
    public class Event
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        private string name;

        private string type;

        private string description;

        public Event()
        {
        }

    }
}