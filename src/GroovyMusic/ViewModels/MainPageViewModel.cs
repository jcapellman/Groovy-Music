using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using GroovyMusic.DI;
using GroovyMusic.Filters.Base;
using GroovyMusic.Interfaces;

using Xamarin.Forms;

namespace GroovyMusic.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
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

        private BaseFilter _selectedFilter;

        public BaseFilter SelectedFilter
        {
            get => _selectedFilter;

            set
            {
                _selectedFilter = value;
                OnPropertyChanged();
            }
        }

        public void LoadData()
        {
            var filters = Assembly.GetAssembly(typeof(BaseFilter)).GetTypes().Where(a => a.BaseType == typeof(BaseFilter))
                .Select(a => (BaseFilter) Activator.CreateInstance(a)).OrderBy(a => a.Name).ToList();

            Filters = new ObservableCollection<BaseFilter>(filters);

            InitializeMusicList();
        }

        private async void InitializeMusicList()
        {
            var songs = await NinjectKernel.DataLayer.GetSongsAsync();

            if (songs.Any())
            {
                return;
            }

            var sources = DependencyService.Get<ISources>().GetSources();

            foreach (var source in sources.Value)
            {
                var music = await source.GetMusicAsync();

                if (music.IsNullOrError)
                {
                    continue;
                }

                var result = await NinjectKernel.DataLayer.AddSongsAsync(music.Value);

                if (!result)
                {
                    continue;
                }
            }        
        }
    }
}