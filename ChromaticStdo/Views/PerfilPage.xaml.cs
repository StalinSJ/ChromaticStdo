using ChromaticStdo.ViewsModels;

namespace ChromaticStdo.Views;

public partial class PerfilPage : ContentPage
{
	public PerfilPage(PerfilViewModel viewModel)
	{
		InitializeComponent();
		BindingContext =viewModel;
	}
}