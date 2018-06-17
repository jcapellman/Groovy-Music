using System.Collections.Generic;
using System.Threading.Tasks;

using GroovyMusic.Common;
using GroovyMusic.Objects;

namespace GroovyMusic.Sources.Base
{
    public abstract class BaseMusicSource
    {
        public abstract string SourceName { get; }

        public abstract Task<ReturnObj<List<MusicMetadataItem>>> GetMusicAsync();
    }
}