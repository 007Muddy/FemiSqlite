using FemiSQLITE.ViewModels;

namespace FemiSQLITE.View;

public partial class HomeFeminhilo : ContentPage
{
    private ItemListPageViewModel _viewMode;
    public HomeFeminhilo(ItemListPageViewModel viewModel)
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