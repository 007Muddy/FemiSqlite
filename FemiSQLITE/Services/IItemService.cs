using FemiSQLITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiSQLITE.Services
{
    public interface IItemService
    {
        Task<List<ItemModel>> GetItemList();
        Task<int> AddItem(ItemModel itemModel);
        Task<int> DeleteItem(ItemModel itemModel);
        Task<int> UpdateItem(ItemModel itemModel);


    }

}
