using System.Globalization;
using System.Threading;

using GroovyMusic.Interfaces;
using GroovyMusic.UWP.InterfaceImplementations;

using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace GroovyMusic.UWP.InterfaceImplementations
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo() => new CultureInfo(Windows.System.UserProfile.GlobalizationPreferences.Languages[0]);

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}