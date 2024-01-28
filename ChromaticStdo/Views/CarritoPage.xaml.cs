using ChromaticStdo.DataAcess;
using ChromaticStdo.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ChromaticStdo.Views;

public partial class CarritoPage : ContentPage
{
	private CarritoViewModel _viewModel;
	private readonly ChromaticStdoDbContext _context;
	public CarritoPage(CarritoViewModel viewModel, ChromaticStdoDbContext contex)
	{
		InitializeComponent();
        _context = contex;
		BindingContext = viewModel;
		_viewModel = viewModel;
	}

    protected override async void OnAppearing()
    {
		await _viewModel.ObtenerProductos();
        _viewModel.MostarTotal();
    }




}