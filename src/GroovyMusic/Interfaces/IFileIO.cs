using System.Collections.Generic;

using GroovyMusic.Objects;

namespace GroovyMusic.Interfaces
{
    public interface IFileIO
    {
        string GetLocalFilePath(string fileName);

        List<MusicMetadataItem> GetMusicFilesList();
    }
}