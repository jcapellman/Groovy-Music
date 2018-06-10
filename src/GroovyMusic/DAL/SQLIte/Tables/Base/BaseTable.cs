using SQLite;

namespace GroovyMusic.DAL.SQLIte.Tables.Base
{
    public class BaseTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Indexed]
        public string Name { get; set; }
    }
}