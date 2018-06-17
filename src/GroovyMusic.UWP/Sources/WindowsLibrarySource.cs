using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.Storage;

using GroovyMusic.Common;
using GroovyMusic.Objects;
using GroovyMusic.Sources;

namespace GroovyMusic.UWP.Sources
{
    public class WindowsLibrarySource : LibraryMusicSource
    {
        private NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public override async Task<ReturnObj<List<MusicMetadataItem>>> GetMusicAsync()
        {
            try
            {
                var storageFolder = KnownFolders.MusicLibrary;
                var files = await storageFolder.GetFilesAsync();

                var musicList = new List<MusicMetadataItem>();

                foreach (var file in files)
                {
                    try
                    {
                        var musicProperties = await file.Properties.GetMusicPropertiesAsync();

                        var track = new MusicMetadataItem
                        {
                            Artist = musicProperties.AlbumArtist,
                            Name = musicProperties.Title,
                            Album = musicProperties.Album,
                            Duration = musicProperties.Duration
                        };

                        musicList.Add(track);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }                    
                }
            
                return new ReturnObj<List<MusicMetadataItem>>(musicList);
            }
            catch (Exception ex)
            {
                return new ReturnObj<List<MusicMetadataItem>>(ex);
            }
        }
    }
}