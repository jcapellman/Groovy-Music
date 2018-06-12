using GroovyMusic.Controls;
using GroovyMusic.Filters.Base;

using Xamarin.Forms;

namespace GroovyMusic.Filters
{
    public class ArtistFilter : BaseFilter
    {
        public override string Name => Resx.AppResources.FILTER_ARTIST_NAME;

        public override ContentView View => new ArtistView();
    }
}