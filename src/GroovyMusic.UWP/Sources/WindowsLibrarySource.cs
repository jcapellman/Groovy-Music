using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.Storage;
using Windows.Storage.Search;

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
                var queryOption = new QueryOptions (CommonFileQuery.OrderByTitle, new[] {".mp3", ".mp4", ".wma", ".flac"})
                {
                    FolderDepth = FolderDepth.Deep
                };

                var files = await KnownFolders.MusicLibrary.CreateFileQueryWithOptions(queryOption).GetFilesAsync();

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
                            Duration = musicProperties.Duration,
                            AlbumReleaseYear = (int?)musicProperties.Year,
                            TrackNumber = (int) musicProperties.TrackNumber
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