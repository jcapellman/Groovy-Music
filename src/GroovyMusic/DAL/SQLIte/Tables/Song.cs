using System;

using GroovyMusic.DAL.SQLIte.Tables.Base;

using SQLite;

namespace GroovyMusic.DAL.SQLIte.Tables
{
    public class Song : BaseTable
    {
        [Indexed]
        public int ArtistID { get; set; }

        [Indexed]
        public int AlbumID { get; set; }

        public int TrackNumber { get; set; }

        public TimeSpan Duration { get; set; }
    }
}