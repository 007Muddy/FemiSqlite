using FemiSQLITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiSQLITE.SearchHandlers
{
    public class ItemSearchHandler:SearchHandler
    {
        public IList<ItemModel> Items { get; set; }
        public string NavigationRoute { get; set; }
        public Type NavigationType { get; set; }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);


            try
            {
                if (string.IsNullOrWhiteSpace(newValue))
                {
                    ItemsSource = null;
                }
                else
                {
                    ItemsSource = Items.Where(item => item.Name.ToLower().Contains(newValue.ToLower())).ToList();
                }

            }
            catch (Exception ex) { }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var navParam = new Dictionary<string, object>();
            navParam.Add("ItemDetail", item);
            if (!string.IsNullOrWhiteSpace(NavigationRoute))
            {
                await Shell.Current.GoToAsync(NavigationRoute, navParam);
            }
        }

    }
}
