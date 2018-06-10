using GroovyMusic.DAL.SQLIte.Tables.Base;

using SQLite;

namespace GroovyMusic.DAL.SQLIte.Tables
{
    public class Album : BaseTable
    {
        [Indexed]
        public int ArtistID { get; set; }
        
        public int? ReleaseYear { get; set; }
    }
}
