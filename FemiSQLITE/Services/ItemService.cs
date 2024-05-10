using FemiSQLITE.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiSQLITE.Services
{
    public class ItemService : IItemService

    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Item.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ItemModel>();
            }
        }

        public async Task<int> AddItem(ItemModel itemModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(itemModel);
        }

        public async Task<int> DeleteItem(ItemModel itemModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(itemModel);
        }

        public async Task<List<ItemModel>> GetItemList()
        {
            await SetUpDb();
            var itemModelList = await _dbConnection.Table<ItemModel>().ToListAsync();
            return itemModelList;
        }

        public async Task<int> UpdateItem(ItemModel itemModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(itemModel);
        }

    }
}
