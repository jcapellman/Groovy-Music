using System;
using System.IO;

using GroovyMusic.Droid.InterfaceImplementations;
using GroovyMusic.Interfaces;

using Xamarin.Forms;

[assembly: Dependency(typeof(FileIO))]
namespace GroovyMusic.Droid.InterfaceImplementations
{
    public class FileIO : IFileIO
    {
        public string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return Path.Combine(path, filename);
        }
    }
}