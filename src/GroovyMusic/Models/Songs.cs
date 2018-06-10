using System;

using GroovyMusic.Models.Base;

namespace GroovyMusic.Models
{
    public class Songs : BaseModel
    {
        public int? TrackNumber { get; set; }

        public TimeSpan Duration { get; set; }
    }
}