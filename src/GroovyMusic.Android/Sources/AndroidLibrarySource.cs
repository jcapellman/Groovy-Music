using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Android.Provider;

using GroovyMusic.Common;
using GroovyMusic.Droid.Common;
using GroovyMusic.Objects;
using GroovyMusic.Sources;

namespace GroovyMusic.Droid.Sources
{
    public class AndroidLibrarySource : LibraryMusicSource
    {
        private NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public override async Task<ReturnObj<List<MusicMetadataItem>>> GetMusicAsync()
        {
            try
            {
                var context = Android.App.Application.Context;

                var musicUri = MediaStore.Audio.Media.ExternalContentUri;

                var musicCursor = context.ContentResolver.Query(musicUri, 
                    new[] {
                        MediaStore.Audio.AudioColumns.Artist,
                        MediaStore.Audio.AudioColumns.Title,
                        MediaStore.Audio.AudioColumns.Album,
                        MediaStore.Audio.AudioColumns.Duration,                        
                    }, null, null, null);

                var musicList = new List<MusicMetadataItem>();

                if (musicCursor.MoveToFirst())
                {
                    do
                    {
                        try
                        {
                            var track = new MusicMetadataItem
                            {
                                Artist = musicCursor.GetStrProperty(MediaStore.Audio.AudioColumns.Artist),
                                Name = musicCursor.GetStrProperty(MediaStore.Audio.AudioColumns.Title),
                                Album = musicCursor.GetStrProperty(MediaStore.Audio.AudioColumns.Album),
                                Duration = TimeSpan.FromMilliseconds(
                                    musicCursor.GetLongProperty(MediaStore.Audio.AudioColumns.Duration))
                            };

                            musicList.Add(track);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex);
                        }
                    } while (musicCursor.MoveToNext());
                }
                
                musicCursor.Close();

                return new ReturnObj<List<MusicMetadataItem>>(musicList);
            }
            catch (Exception ex)
            {
                return new ReturnObj<List<MusicMetadataItem>>(ex);
            }
        }
    }
}