using System.Collections.Generic;

using GroovyMusic.Common;
using GroovyMusic.Droid.InterfaceImplementations;
using GroovyMusic.Droid.Sources;
using GroovyMusic.Interfaces;
using GroovyMusic.Sources.Base;

using Xamarin.Forms;

[assembly: Dependency(typeof(Sources))]
namespace GroovyMusic.Droid.InterfaceImplementations
{
    public class Sources : ISources
    {
        public ReturnObj<List<BaseMusicSource>> GetSources() => new ReturnObj<List<BaseMusicSource>>(new List<BaseMusicSource> { new AndroidLibrarySource() });
    }
}