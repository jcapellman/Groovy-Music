using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Android.Media;

using GroovyMusic.Droid.InterfaceImplementations;
using GroovyMusic.Interfaces;
using GroovyMusic.Objects;

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

        public List<MusicMetadataItem> GetMusicFilesList()
        {
            var files = Directory.GetFiles(Android.OS.Environment.DirectoryMusic).ToList();

            var mretriever = new MediaMetadataRetriever();

            var musicList = new List<MusicMetadataItem>();

            foreach (var file in files)
            {
                mretriever.SetDataSource(file);

                var item = new MusicMetadataItem
                {
                    Name = mretriever.ExtractMetadata(MetadataKey.Title),
                    Artist = mretriever.ExtractMetadata(MetadataKey.Albumartist)
                };

                musicList.Add(item);
            }

            return musicList;
        }
    }
}