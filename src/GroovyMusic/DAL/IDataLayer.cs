using System.Collections.Generic;
using System.Threading.Tasks;

using GroovyMusic.Models;
using GroovyMusic.Objects;

namespace GroovyMusic.DAL
{
    public interface IDataLayer
    {
        Task<List<Songs>> GetSongsAsync(string searchQuery = null);

        Task<List<Artists>> GetArtistsAsync(string searchQuery = null);

        Task<List<Albums>> GetAlbumsAsync(string searchQuery = null);

        Task<List<Albums>> GetArtistAlbumsAsync(int artistID);

        Task<List<Songs>> GetAlbumTracksAsync(int albumID);

        Task<bool> AddSongsAsync(List<MusicMetadataItem> songs);
    }
}