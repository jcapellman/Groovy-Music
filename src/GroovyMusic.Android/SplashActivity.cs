using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace GroovyMusic.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            var startupWork = new Task(StartupAppAsync);
            
            startupWork.Start();
        }
        
        public override void OnBackPressed() { }
        
        async void StartupAppAsync()
        {
            await Task.Delay(1000);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}