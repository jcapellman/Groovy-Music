using Xamarin.Forms;

namespace GroovyMusic.Filters.Base
{
    public abstract class BaseFilter
    {
        public abstract string Name { get; }

        public abstract ContentView View { get; }
    }
}