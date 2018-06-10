using GroovyMusic.DAL.SQLIte.Tables.Base;

namespace GroovyMusic.DAL.SQLIte.Tables
{
    public class Artist : BaseTable
    {
        public string Genre { get; set; }

        public int NumberAlbums { get; set; }

        public int NumberSongs { get; set; }
    }
}