using FemiSQLITE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiSQLITE.Services
{
    public static class CartService
    {
        public static ObservableCollection<ItemModel> CartItems { get; set; } = new ObservableCollection<ItemModel>();

        public static void Add(ItemModel item)
        {
            CartItems.Add(item);
            // Notify if needed
            MessagingCenter.Send(typeof(CartService), "CartUpdated");
        }
    }

}
