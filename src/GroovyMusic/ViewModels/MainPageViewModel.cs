using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

using GroovyMusic.Filters.Base;
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

        private ObservableCollection<BaseFilter> _filters;

        public ObservableCollection<BaseFilter> Filters
        {
            get => _filters;

            set
            {
                _filters = value;
                OnPropertyChanged();
            }
        }

        public async void LoadData()
        {
            var filters = Assembly.GetAssembly(typeof(BaseFilter)).GetTypes().Where(a => a.BaseType == typeof(BaseFilter))
                .Select(a => (BaseFilter) Activator.CreateInstance(a)).OrderBy(a => a.Name).ToList();

            Filters = new ObservableCollection<BaseFilter>(filters);

            Artists = new ObservableCollection<Artists>(await App.Database.GetArtistsAsync());
        }
    }
}