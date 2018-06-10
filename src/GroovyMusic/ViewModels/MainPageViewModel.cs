using System.Collections.ObjectModel;

using GroovyMusic.Models;

namespace GroovyMusic.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Artists> _artists;

        public ObservableCollection<Artists> Artists
        {
            get => _artists;
            set { _artists = value; OnPropertyChanged(); }
        }

        public async void LoadData()
        {
            Artists = new ObservableCollection<Artists>(await App.Database.GetArtistsAsync());
        }
    }
}