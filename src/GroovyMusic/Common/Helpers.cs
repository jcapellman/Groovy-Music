using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GroovyMusic.Common
{
    public class Helpers
    {
        public static ReturnObj<List<T>> GetObjects<T>()
        {
            try
            {
                var objects = Assembly.GetCallingAssembly().GetTypes().Where(a => a.BaseType == typeof(T))
                    .Select(a => (T) Activator.CreateInstance(typeof(T))).ToList();

                return new ReturnObj<List<T>>(objects);
            }
            catch (Exception ex)
            {
                return new ReturnObj<List<T>>(ex);
            }
        }
    }
}