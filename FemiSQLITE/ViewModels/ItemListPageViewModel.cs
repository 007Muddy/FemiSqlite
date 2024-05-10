using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FemiSQLITE.Models;
using FemiSQLITE.Services;
using FemiSQLITE.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiSQLITE.ViewModels
{
    public partial class ItemListPageViewModel: ObservableObject
    {
        public static List<ItemModel> ItemsListForSearch { get; private set; } = new List<ItemModel>();

        public ObservableCollection<ItemModel> Items { get; set; } = new ObservableCollection<ItemModel>();

        private readonly IItemService _itemService;
        public ItemListPageViewModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        [RelayCommand]
        public async void GetItemList()
        {
            Items.Clear();
            var itemList = await _itemService.GetItemList();
            if (itemList?.Count > 0)
            {
                itemList = itemList.OrderBy(f => f.Name).ToList();
                foreach (var item in itemList)
                {
                    Items.Add(item);
                }
                ItemsListForSearch.Clear();
               ItemsListForSearch.AddRange(itemList);
            }
        }

        [RelayCommand]
        public async void AddUpdateItem()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateItemDetail));
        }

        [RelayCommand]
        public async void EditItem(ItemModel itemModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("ItemDetail", itemModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateItemDetail), navParam);
        }

        [RelayCommand]
        public async void DeleteItem(ItemModel itemModel)
        {
            var delResponse = await _itemService.DeleteItem(itemModel);
            if (delResponse > 0)
            {
                GetItemList();
            }
        }


        //[RelayCommand]
        //public async void AddToCart()
        //{
        //    await AppShell.Current.GoToAsync(nameof(Cart));
        //}

        [RelayCommand]
        public async void DisplayAction(ItemModel itemModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("ItemDetail", itemModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateItemDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _itemService.DeleteItem(itemModel);
                if (delResponse > 0)
                {
                    GetItemList();
                }
            }
        }

    }
}
