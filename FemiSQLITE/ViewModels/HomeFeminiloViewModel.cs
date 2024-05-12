using System.Collections.ObjectModel;
using FemiSQLITE.Models;
using System.Windows.Input;
using System.Diagnostics;
using System.Xml.Linq;


namespace FemiSQLITE.ViewModels
{
    public class HomeFeminiloViewModel
    {
        public ObservableCollection<ItemModel> Items { get; set; }
        public ICommand AddToCartCommand { get; private set; }

        // Assuming a simple cart represented as a list
        private ObservableCollection<ItemModel> Cart { get; set; }

        public HomeFeminiloViewModel()
        {
            Items = new ObservableCollection<ItemModel>();
            Cart = new ObservableCollection<ItemModel>(); // Initialize the cart
            AddToCartCommand = new Command<ItemModel>(AddToCart);
            LoadItems();  // Populate Items with sample data
        }

        private void AddToCart(ItemModel item)
        {
            // Add the item to the cart
            Cart.Add(item);

            // For debugging: Output the action to the console or debug window
            System.Diagnostics.Debug.WriteLine($"Adding {item.Name} to cart with price {item.Price}");
        }

        private void LoadItems()
        {
            // Add sample items to the Items collection
            Items.Add(new ItemModel { Name = "Laptop", Price = 1200.00, Description = "High-performance laptop", ImageUrl = "http://example.com/laptop.png" });
            Items.Add(new ItemModel { Name = "Smartphone", Price = 800.00, Description = "Latest model smartphone", ImageUrl = "http://example.com/smartphone.png" });
            Items.Add(new ItemModel { Name = "Headphones", Price = 150.00, Description = "Noise cancelling headphones", ImageUrl = "http://example.com/headphones.png" });
        }
    }

}
