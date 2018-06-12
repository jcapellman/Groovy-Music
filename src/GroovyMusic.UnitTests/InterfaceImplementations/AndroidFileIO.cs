using GroovyMusic.Droid.InterfaceImplementations;

using NUnit.Framework;

namespace GroovyMusic.UnitTests.Droid.InterfaceImplementations
{
    public class AndroidFileIO
    {
        [Test]
        public void AndroidFileIO_EmptyFiles()
        {
            var fileIO = new FileIO();

            var files = fileIO.GetMusicFilesList();

            Assert.IsNotNull(files);
        }
    }
}
