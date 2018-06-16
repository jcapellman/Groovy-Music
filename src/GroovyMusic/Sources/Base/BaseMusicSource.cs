using System.Collections.Generic;

using GroovyMusic.Common;
using GroovyMusic.Objects;

namespace GroovyMusic.Sources.Base
{
    public abstract class BaseMusicSource
    {
        public abstract string SourceName { get; }

        public abstract ReturnObj<List<MusicMetadataItem>> GetMusic();
    }
}