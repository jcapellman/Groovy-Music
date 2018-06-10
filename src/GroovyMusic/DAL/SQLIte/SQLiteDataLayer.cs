using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GroovyMusic.DAL.SQLIte.Tables;
using GroovyMusic.Models;

using SQLite;

namespace GroovyMusic.DAL.SQLIte
{
    public class SQLiteDataLayer : IDataLayer
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteDataLayer(string pathToDB)
        {
            _database = new SQLiteAsyncConnection(pathToDB);
            _database.CreateTableAsync<Song>().Wait();
        }

        public async Task<List<Songs>> GetSongsAsync(string searchQuery = null) => 
            (await _database.Table<Song>().ToListAsync()).Select(a => new Songs
            {
                Duration = a.Duration,
                Name = a.Name,
                TrackNumber = a.TrackNumber
            }).ToList();

        public async Task<List<Artists>> GetArtistsAsync(string searchQuery = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Albums>> GetAlbumsAsync(string searchQuery = null)
        {
            throw new NotImplementedException();
        }
    }
}