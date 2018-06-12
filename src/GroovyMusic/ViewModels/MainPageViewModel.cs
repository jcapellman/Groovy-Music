using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

using GroovyMusic.Filters.Base;

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
        }
    }
}