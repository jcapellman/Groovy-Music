using System.Linq;

using GroovyMusic.Common;
using GroovyMusic.DAL.SQLIte;
using GroovyMusic.Interfaces;
using GroovyMusic.Views;

using Ninject;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IDataLayer = GroovyMusic.DAL.IDataLayer;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace GroovyMusic
{
	public partial class App
	{
	    public static StandardKernel Kernel;
        
	    private static void InitializeLocalization()
	    {
	        var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
	        Resx.AppResources.Culture = ci;
	        DependencyService.Get<ILocalize>().SetLocale(ci);
	    }
        
	    private static async void InitializeMusicList()
	    {
	        var songs = await Kernel.Get<IDataLayer>().GetSongsAsync();

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

	            var result = await Kernel.Get<IDataLayer>().AddSongsAsync(music.Value);

	            if (!result)
	            {
	                continue;
	            }
	        }
	    }

	    private static void InitializeDi()
	    {
	        Kernel = new StandardKernel();

	        var dbFileName = DependencyService.Get<IFileIO>().GetLocalFilePath(Constants.FILENAME_SQLITE_DB);

	        if (dbFileName.IsNullOrError)
	        {
	            return;
	        }

	        Kernel.Bind<IDataLayer>().To<SQLiteDataLayer>().WithConstructorArgument("pathToDb", dbFileName.Value);
	    }

        public App ()
		{
			InitializeComponent();

		    InitializeDi();

            InitializeLocalization();
            
            InitializeMusicList();

            MainPage = new MainPage();
		}
	}
}