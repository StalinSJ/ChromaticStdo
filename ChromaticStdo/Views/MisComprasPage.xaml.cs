using ChromaticStdo.DataAcess;
using ChromaticStdo.ViewsModels;

namespace ChromaticStdo.Views;

public partial class MisComprasPage : ContentPage
{
	private readonly MisComprasViewModel _viewModel;
	public MisComprasPage(MisComprasViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
	}

    protected override async void OnAppearing()
    {
		await _viewModel.ObtenerCompras();
    }


}