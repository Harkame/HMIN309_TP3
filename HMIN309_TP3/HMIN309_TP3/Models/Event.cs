using SQLite;

namespace HMIN309_TP3.Models
{
    [Table("Events")]
    public class Event
    {
        [PrimaryKey, AutoIncrement, Column("event_id")]
        public int Id { get; set; }

        [NotNull, Column("event_name")]
        public string Name { get; set; }

        [NotNull, Column("event_date")]
        public long Date { get; set; }

        [NotNull, Column("date_text")]
        public string DateText { get; set; }

        [NotNull, Column("event_type")]
        public string Type { get; set; }

        [Column("event_description")]
        public string Description { get; set; }

        [Column("event_file_path")]
        public string FilePath { get; set; }

        [Column("event_address")]
        public string Address { get; set; }

        [Column("event_latitude")]
        public double Latitude { get; set; }

        [Column("event_longitude")]
        public double Longitude { get; set; }
    }
}