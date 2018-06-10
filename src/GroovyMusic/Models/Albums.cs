using GroovyMusic.Models.Base;

namespace GroovyMusic.Models
{
    public class Albums : BaseModel
    {
        public string ArtistName { get; set; }

        public int? YearReleased { get; set; }
    }
}