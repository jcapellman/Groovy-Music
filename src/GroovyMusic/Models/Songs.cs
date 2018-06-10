using System;

namespace GroovyMusic.Models
{
    public class Songs
    {
        public string Name { get; set; }

        public int? TrackNumber { get; set; }

        public TimeSpan Duration { get; set; }
    }
}