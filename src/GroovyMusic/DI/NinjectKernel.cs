using GroovyMusic.Common;
using GroovyMusic.DAL;
using GroovyMusic.DAL.SQLIte;
using GroovyMusic.Interfaces;

using Ninject;

using Xamarin.Forms;

namespace GroovyMusic.DI
{
    public static class NinjectKernel
    {
        private static IKernel Kernel { get; set; } = new StandardKernel();

        public static void Setup()
        {
            var dbFileName = DependencyService.Get<IFileIO>().GetLocalFilePath(Constants.FILENAME_SQLITE_DB);

            if (dbFileName.IsNullOrError)
            {
                return;
            }

            Kernel.Bind<IDataLayer>().To<SQLiteDataLayer>().WithConstructorArgument("pathToDb", dbFileName.Value);
        }

        public static IDataLayer DataLayer => Kernel.Get<IDataLayer>();
    }
}