using System.Collections.ObjectModel;

using GroovyMusic.DAL;
using GroovyMusic.Models;
using GroovyMusic.ViewModels;

using Ninject;

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

        public async void LoadDataAsync()
        {
            var artists = await App.Kernel.Get<IDataLayer>().GetArtistsAsync();

            Artists = new ObservableCollection<Artists>(artists);
        }
    }
}