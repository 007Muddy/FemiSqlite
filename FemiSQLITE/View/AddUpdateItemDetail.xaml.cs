using FemiSQLITE.ViewModels;

namespace FemiSQLITE.View;

public partial class AddUpdateItemDetail : ContentPage
{
	public AddUpdateItemDetail(AddUpdateItemDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}