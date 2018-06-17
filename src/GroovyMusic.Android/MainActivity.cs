using Android.App;
using Android.Content.PM;
using Android.OS;

using GroovyMusic.DI;

namespace GroovyMusic.Droid
{
    [Activity(Label = "Groovy Music", Icon = "@mipmap/icon", Theme = "@style/MainTheme", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            NinjectKernel.Setup();

            LoadApplication(new App());
        }
    }
}