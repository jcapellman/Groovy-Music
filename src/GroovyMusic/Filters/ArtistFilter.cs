using GroovyMusic.Filters.Base;

namespace GroovyMusic.Filters
{
    public class ArtistFilter : BaseFilter
    {
        public override string Name => Resx.AppResources.FILTER_ARTIST_NAME;
    }
}