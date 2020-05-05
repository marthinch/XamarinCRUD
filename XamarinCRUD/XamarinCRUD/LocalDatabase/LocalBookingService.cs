using XamarinCRUD.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCRUD.Helpers;

namespace XamarinCRUD.LocalDatabase
{
    public class LocalBookingService : IBaseCrud<SampleModel>
    {
        private SQLiteAsyncConnection Database;

        public LocalBookingService()
        {
            LocalDBHelper.Initialize<SampleModel>();

            Database = LocalDBHelper.Database.Value;
        }

        public Task<int> DeleteAsync(SampleModel item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<List<SampleModel>> GetAllAsync()
        {
            return Database.Table<SampleModel>().ToListAsync();
        }

        public Task<SampleModel> GetItemAsync(int id)
        {
            return Database.Table<SampleModel>().FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<int> SaveAsync(SampleModel item)
        {
            return Database.InsertAsync(item);
        }

        public Task<int> UpdateAsync(SampleModel item)
        {
            return Database.UpdateAsync(item);
        }
    }
}
