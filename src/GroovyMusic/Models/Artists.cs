using GroovyMusic.Models.Base;

namespace GroovyMusic.Models
{
    public class Artists : BaseModel
    {
        public int NumberAlbums { get; set; }

        public int NumberSongs { get; set; }

        public string Genre { get; set; }
    }
}