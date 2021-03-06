﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GroovyMusic.DAL.SQLIte.Tables;
using GroovyMusic.Models;
using GroovyMusic.Objects;

using SQLite;

namespace GroovyMusic.DAL.SQLIte
{
    public class SQLiteDataLayer : IDataLayer
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteDataLayer(string pathToDb)
        {
            _database = new SQLiteAsyncConnection(pathToDb);

            _database.CreateTableAsync<Artist>().Wait();
            _database.CreateTableAsync<Album>().Wait();
            _database.CreateTableAsync<Song>().Wait();
        }

        public async Task<List<Songs>> GetSongsAsync(string searchQuery = null) => 
            (await _database.Table<Song>().ToListAsync()).Select(a => new Songs
            {
                Duration = a.Duration,
                Name = a.Name,
                TrackNumber = a.TrackNumber
            }).ToList();

        public async Task<List<Artists>> GetArtistsAsync(string searchQuery = null) =>    
            (await _database.Table<Artist>().ToListAsync()).Select(a => new Artists
            {
                Name = a.Name,
                Genre = a.Genre,
                ID = a.ID,
                NumberAlbums = a.NumberAlbums,
                NumberSongs = a.NumberSongs
            }).ToList();
    

        public async Task<List<Albums>> GetAlbumsAsync(string searchQuery = null) =>
            (await _database.Table<Album>().ToListAsync()).Select(a => new Albums
            {
                Name = a.Name,
                ID = a.ID,
                ArtistName = string.Empty,
                YearReleased = a.ReleaseYear
            }).ToList();

        public async Task<List<Albums>> GetArtistAlbumsAsync(int artistID) =>
            (await _database.Table<Album>().Where(a => a.ArtistID == artistID).OrderByDescending(a => a.ReleaseYear).ToListAsync()).Select(a => new Albums
            {
                Name = a.Name,
                ID = a.ID,
                ArtistName = string.Empty,
                YearReleased = a.ReleaseYear
            }).ToList();

        public async Task<List<Songs>> GetAlbumTracksAsync(int albumID) =>
            (await _database.Table<Song>().Where(a => a.AlbumID == albumID).OrderBy(a => a.TrackNumber).ToListAsync()).Select(a => new Songs
            {
                Name = a.Name,
                ID = a.ID,
                TrackNumber = a.TrackNumber,
                Duration = a.Duration
            }).ToList();

        private async Task<int> GetOrCreateArtistAsync(string name)
        {
            var artist = await _database.Table<Artist>().Where(a => a.Name == name)
                .FirstOrDefaultAsync();

            if (artist != null)
            {
                return artist.ID;
            }

            artist = new Artist
            {
                Name = name,
                Genre = string.Empty,
                NumberAlbums = 0,
                NumberSongs = 0
            };

            await _database.InsertAsync(artist);

            return artist.ID;
        }

        private async Task<int> GetOrCreateAlbumAsync(string name, int? releaseYear)
        {
            var album = await _database.Table<Album>().Where(a => a.Name == name)
                .FirstOrDefaultAsync();

            if (album != null)
            {
                return album.ID;
            }

            album = new Album
            {
                Name = name,
                ReleaseYear = releaseYear
            };

            await _database.InsertAsync(album);

            return album.ID;
        }

        public async Task<bool> AddSongsAsync(List<MusicMetadataItem> songs)
        {
            var artists = new Dictionary<string, int>();
            var albums = new Dictionary<string, int>();

            foreach (var song in songs)
            {
                var songItem = new Song
                {
                    Name = song.Name,
                    TrackNumber = song.TrackNumber,
                    Duration = song.Duration
                };

                if (!artists.ContainsKey(song.Artist))
                {
                    var artistId = await GetOrCreateArtistAsync(song.Artist);

                    artists.Add(song.Artist, artistId);

                    songItem.ArtistID = artistId;
                }
                else
                {
                    songItem.ArtistID = artists[song.Artist];
                }

                if (!albums.ContainsKey(song.Album))
                {
                    var albumId = await GetOrCreateAlbumAsync(song.Album, song.AlbumReleaseYear);

                    albums.Add(song.Album, albumId);

                    songItem.AlbumID = albumId;
                }
                else
                {
                    songItem.AlbumID = albums[song.Album];
                }

                await _database.InsertAsync(songItem);
            }

            return true;
        }
    }
}