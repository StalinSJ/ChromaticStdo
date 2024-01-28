using ChromaticStdo.ViewsModels;

namespace ChromaticStdo.Views;

public partial class DireccionPage : ContentPage
{
	public DireccionPage(DireccionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}