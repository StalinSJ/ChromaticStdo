using ChromaticStdo.ViewsModels;

namespace ChromaticStdo.Views;

public partial class TarjetaPage : ContentPage
{
	public TarjetaPage(TarjetaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}