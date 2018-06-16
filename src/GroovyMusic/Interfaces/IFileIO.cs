using GroovyMusic.Common;

namespace GroovyMusic.Interfaces
{
    public interface IFileIO
    {
        ReturnObj<string> GetLocalFilePath(string fileName);
    }
}