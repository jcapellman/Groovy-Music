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

            var startupWork = new Task(SimulateStartup);

            startupWork.Start();
        }
        
        public override void OnBackPressed() { }
        
        async void SimulateStartup()
        {
            await Task.Delay(2000);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}