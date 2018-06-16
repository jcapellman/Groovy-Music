using Android.Database;

namespace GroovyMusic.Droid.Common
{
    public static class Extensions
    {
        public static string GetStrProperty(this ICursor cursor, string property) =>
            cursor.GetString(cursor.GetColumnIndexOrThrow(property));

        public static long GetLongProperty(this ICursor cursor, string property) =>
            cursor.GetLong(cursor.GetColumnIndexOrThrow(property));
    }
}