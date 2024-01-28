using ChromaticStdo.ViewsModels;

namespace ChromaticStdo.Views;

public partial class CompraExitosaPage : ContentPage
{
	public CompraExitosaPage(CompraExitosaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}