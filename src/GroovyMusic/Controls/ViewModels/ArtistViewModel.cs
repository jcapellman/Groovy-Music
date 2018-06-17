using System.Collections.ObjectModel;

using GroovyMusic.DI;
using GroovyMusic.Models;
using GroovyMusic.ViewModels;

namespace GroovyMusic.Controls.ViewModels
{
    public class ArtistViewModel : BaseViewModel
    {
        private ObservableCollection<Artists> _artists;

        public ObservableCollection<Artists> Artists
        {
            get => _artists;
            set { _artists = value; OnPropertyChanged(); }
        }
        
        public ArtistViewModel() { }

        public async void LoadDataAsync()
        {
            var artists = await NinjectKernel.DataLayer.GetArtistsAsync();

            Artists = new ObservableCollection<Artists>(artists);
        }
    }
}