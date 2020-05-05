using SQLite;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XamarinCRUD.Extensions;

namespace XamarinCRUD.Helpers
{
    public static class LocalDBHelper
    {
        public const string DatabaseFilename = "LocalDB.db3";

        public const SQLite.SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |     // open the database in read/write mode
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

        public static readonly Lazy<SQLiteAsyncConnection> Database = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DatabasePath, Flags);
        });

        private static async Task InitializeDatabaseAsync<T>() where T : class
        {
            if (!Database.Value.TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
            {
                await Database.Value.CreateTablesAsync(CreateFlags.None, typeof(T));
            }
        }

        public static void Initialize<T>() where T : class
        {
            InitializeDatabaseAsync<T>().SafeFireAndForget(false);
        }
    }
}
