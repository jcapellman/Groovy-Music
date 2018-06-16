using System.Linq;

using GroovyMusic.Common;
using GroovyMusic.DAL;
using GroovyMusic.DAL.SQLIte;
using GroovyMusic.Interfaces;
using GroovyMusic.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace GroovyMusic
{
	public partial class App
	{
	    public static IDataLayer Database;

	    private static void InitializeLocalization()
	    {
	        var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
	        Resx.AppResources.Culture = ci;
	        DependencyService.Get<ILocalize>().SetLocale(ci);
	    }

	    private static void InitializeDatabase()
	    {
            var dbFileName = DependencyService.Get<IFileIO>().GetLocalFilePath(Constants.FILENAME_SQLITE_DB);

            if (dbFileName.IsNullOrError)
            {
                return;
            }

            Database = new SQLiteDataLayer(dbFileName.Value);
	    }

	    private static async void InitializeMusicList()
	    {
	        var songs = await Database.GetSongsAsync();

	        if (songs.Any())
	        {
	            return;
	        }

	        var sources = DependencyService.Get<ISources>().GetSources();

	        foreach (var source in sources.Value)
	        {
	            var music = source.GetMusic();

	            if (music.IsNullOrError)
	            {
	                continue;
	            }

	            var result = await Database.AddSongsAsync(music.Value);

	            if (!result)
	            {
	                continue;
	            }
	        }
	    }
        
        public App ()
		{
			InitializeComponent();
            
            InitializeLocalization();

            InitializeDatabase();

            InitializeMusicList();

            MainPage = new MainPage();
		}
	}
}