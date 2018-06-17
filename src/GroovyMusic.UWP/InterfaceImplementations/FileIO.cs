using System.IO;

using Windows.Storage;

using GroovyMusic.Common;
using GroovyMusic.Interfaces;

using Xamarin.Forms;
using FileIO = GroovyMusic.UWP.InterfaceImplementations.FileIO;

[assembly: Dependency(typeof(FileIO))]
namespace GroovyMusic.UWP.InterfaceImplementations
{
    public class FileIO : IFileIO
    {
        public ReturnObj<string> GetLocalFilePath(string filename) => new ReturnObj<string>(Path.Combine(ApplicationData.Current.LocalFolder.Path, filename));
    }
}