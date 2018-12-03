using SQLite;

namespace HMIN309_TP3.Models
{
    [Table("Events")]
    public class Event
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [NotNull, Column("name")]
        public string Name { get; set; }

        [NotNull, Column("date")]
        public long Date { get; set; }

        [NotNull, Column("type")]
        public string Type { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}