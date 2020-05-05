using SQLite;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XamarinCRUD.Extensions;
using XamarinCRUD.Models;

namespace XamarinCRUD.Helpers
{
    public static class LocalDBHelper
    {
        public const string DatabaseFilename = "LocalDB.db3";

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |     // open the database in read/write mode
                                             SQLiteOpenFlags.Create |        // create the database if it doesn't exist
                                             SQLiteOpenFlags.SharedCache;    // enable multi-threaded database access

        private static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        public static SQLiteAsyncConnection Database()
        {
            return new SQLiteAsyncConnection(DatabasePath, Flags);
        }

        private static async Task InitializeDatabaseAsync<T>() where T : class
        {
            if (!Database().TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
            {
                await Database().CreateTablesAsync(CreateFlags.None, typeof(T)).ConfigureAwait(false);
            }
        }

        public static async void Initialize<T>() where T : class
        {
            await InitializeDatabaseAsync<T>();
        }
    }
}
