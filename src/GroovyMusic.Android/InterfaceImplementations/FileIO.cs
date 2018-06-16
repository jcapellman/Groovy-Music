using System;
using System.IO;

using GroovyMusic.Common;
using GroovyMusic.Droid.InterfaceImplementations;
using GroovyMusic.Interfaces;

using Xamarin.Forms;

[assembly: Dependency(typeof(FileIO))]
namespace GroovyMusic.Droid.InterfaceImplementations
{
    public class FileIO : IFileIO
    {
        public ReturnObj<string> GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return new ReturnObj<string>(Path.Combine(path, filename));
        }
    }
}