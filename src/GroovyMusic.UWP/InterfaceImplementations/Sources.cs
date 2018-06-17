using System.Collections.Generic;

using GroovyMusic.Common;
using GroovyMusic.Interfaces;
using GroovyMusic.Sources.Base;
using GroovyMusic.UWP.InterfaceImplementations;
using GroovyMusic.UWP.Sources;

using Xamarin.Forms;

[assembly: Dependency(typeof(Sources))]
namespace GroovyMusic.UWP.InterfaceImplementations
{
    public class Sources : ISources
    {
        public ReturnObj<List<BaseMusicSource>> GetSources() => new ReturnObj<List<BaseMusicSource>>(new List<BaseMusicSource> { new WindowsLibrarySource() });
    }
}