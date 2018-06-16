﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Android.Media;

using GroovyMusic.Common;
using GroovyMusic.Objects;
using GroovyMusic.Sources;

namespace GroovyMusic.Droid.Sources
{
    public class AndroidLibrarySource : LibraryMusicSource
    {
        public override ReturnObj<List<MusicMetadataItem>> GetMusic()
        {
            try
            {
                var files = Directory.GetFiles(Android.OS.Environment.DirectoryMusic).ToList();

                var mretriever = new MediaMetadataRetriever();

                var musicList = new List<MusicMetadataItem>();

                foreach (var file in files)
                {
                    mretriever.SetDataSource(file);

                    var item = new MusicMetadataItem
                    {
                        Name = mretriever.ExtractMetadata(MetadataKey.Title) ??
                               GroovyMusic.Resx.AppResources.DEFAULTS_METADATA_UNKNOWN_SONG,
                        Artist = mretriever.ExtractMetadata(MetadataKey.Albumartist) ??
                                 Resx.AppResources.DEFAULTS_METADATA_UNKNOWN_ARTIST,
                        Album = mretriever.ExtractMetadata(MetadataKey.Album) ??
                                Resx.AppResources.DEFAULTS_METADATA_UNKNOWN_ALBUM,
                        Duration = TimeSpan.Zero
                    };

                    if (!string.IsNullOrEmpty(mretriever.ExtractMetadata(MetadataKey.CdTrackNumber)))
                    {
                        item.TrackNumber = Convert.ToInt32(mretriever.ExtractMetadata(MetadataKey.CdTrackNumber));
                    }

                    musicList.Add(item);
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