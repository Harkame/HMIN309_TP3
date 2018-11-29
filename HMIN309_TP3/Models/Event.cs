using SQLite;
using System.ComponentModel;

namespace HMIN309_TP3.Models
{
    [Table("Events")]
    public class Event : INotifyPropertyChanged
    {
        private int id;

        private string date; //TODO Change to date

        private string name;

        private string type;

        private string description;

        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        [NotNull, Column("date")]
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        [NotNull, Column("name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [NotNull, Column("type")]
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        [NotNull, Column("description")]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public Event()
        {
        }

        public Event(string name, string type, string description)
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}