using XamarinCRUD.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCRUD.Helpers;

namespace XamarinCRUD.LocalDatabase
{
    public class LocalBookingService : IBaseCrud<Booking>
    {
        private SQLiteAsyncConnection Database;

        public LocalBookingService()
        {
            LocalDBHelper.Initialize<Booking>();

            Database = LocalDBHelper.Database();
        }

        public Task<int> DeleteAsync(Booking item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<List<Booking>> GetAllAsync()
        {
            return Database.Table<Booking>().ToListAsync();
        }

        public Task<Booking> GetItemAsync(string id)
        {
            return Database.Table<Booking>().FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<int> SaveAsync(Booking item)
        {
            return Database.InsertAsync(item);
        }

        public Task<int> UpdateAsync(Booking item)
        {
            return Database.UpdateAsync(item);
        }
    }
}
