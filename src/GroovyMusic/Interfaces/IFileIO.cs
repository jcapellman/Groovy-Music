using System.Collections.Generic;

using GroovyMusic.Common;
using GroovyMusic.Objects;

namespace GroovyMusic.Interfaces
{
    public interface IFileIO
    {
        ReturnObj<string> GetLocalFilePath(string fileName);

        ReturnObj<List<MusicMetadataItem>> GetMusicFilesList();
    }
}