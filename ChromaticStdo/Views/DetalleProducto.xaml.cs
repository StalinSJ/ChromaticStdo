using ChromaticStdo.ViewsModels;

namespace ChromaticStdo.Views;

public partial class DetalleProducto : ContentPage
{
	public DetalleProducto(DetalleProductoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}