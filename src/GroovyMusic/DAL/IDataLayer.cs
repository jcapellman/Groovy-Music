using System.Collections.Generic;
using System.Threading.Tasks;

using GroovyMusic.Models;

namespace GroovyMusic.DAL
{
    public interface IDataLayer
    {
        Task<List<Songs>> GetSongsAsync(string searchQuery = null);

        Task<List<Artists>> GetArtistsAsync(string searchQuery = null);

        Task<List<Albums>> GetAlbumsAsync(string searchQuery = null);
    }
}