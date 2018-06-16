using System.Collections.Generic;

using GroovyMusic.Common;
using GroovyMusic.Sources.Base;

namespace GroovyMusic.Interfaces
{
    public interface ISources
    {
        ReturnObj<List<BaseMusicSource>> GetSources();
    }
}