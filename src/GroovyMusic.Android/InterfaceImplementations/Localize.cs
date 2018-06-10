using System.Globalization;
using System.Threading;

using GroovyMusic.Droid.InterfaceImplementations;
using GroovyMusic.Interfaces;

using Naxam.I18n;

using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace GroovyMusic.Droid.InterfaceImplementations
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));
            
            CultureInfo ci;

            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException)
            {
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));  

                    ci = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException)
                {
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }

        private static string AndroidToDotnetLanguage(string androidLanguage) => androidLanguage;

        private static string ToDotnetFallbackLanguage(PlatformCulture platCulture) => platCulture.LanguageCode;

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}