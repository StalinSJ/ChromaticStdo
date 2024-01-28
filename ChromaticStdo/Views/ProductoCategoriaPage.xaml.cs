using ChromaticStdo.ViewsModels;

namespace ChromaticStdo.Views;

public partial class ProductoCategoriaPage : ContentPage
{
	public ProductoCategoriaPage(ProductoCategoriaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}