using FemiSQLITE.ViewModels;

namespace FemiSQLITE.View;

public partial class ItemListPage : ContentPage
{
    private ItemListPageViewModel _viewMode;
    public ItemListPage(ItemListPageViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetItemListCommand.Execute(null);
    }
}