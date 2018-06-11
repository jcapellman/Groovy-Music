using System;

namespace GroovyMusic.Objects
{
    public class MusicMetadataItem
    {
        public string Name { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public int? AlbumReleaseYear { get; set; }

        public int TrackNumber { get; set; }

        public TimeSpan Duration { get; set; }
    }
}