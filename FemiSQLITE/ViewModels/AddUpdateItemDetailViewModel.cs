using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FemiSQLITE.Models;
using FemiSQLITE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiSQLITE.ViewModels
{
   [QueryProperty(nameof(ItemDetail), "ItemDetail")]
    public partial class AddUpdateItemDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private ItemModel _itemDetail = new ItemModel();

        private readonly IItemService _itemService;
        public AddUpdateItemDetailViewModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        [RelayCommand]
        public async void AddUpdateItem()
        {
            int response = -1;
            if (ItemDetail.ID > 0)
            {
                response = await _itemService.UpdateItem(ItemDetail);
            }
            else
            {
                response = await _itemService.AddItem(new Models.ItemModel
                {
                    Name = ItemDetail.Name,
                    Price = ItemDetail.Price,
                    Description = ItemDetail.Description,
                    ImageUrl = ItemDetail.ImageUrl,

                });
            }

        

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Item Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }
    }
}
