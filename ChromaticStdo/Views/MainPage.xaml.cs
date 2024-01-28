using ChromaticStdo.DataAcess;
using ChromaticStdo.ViewsModels;

namespace ChromaticStdo.Views;

public partial class MainPage : ContentPage
{
	int count = 0;
	private readonly ChromaticStdoDbContext _context;
	public MainPage(ChromaticStdoDbContext context, MainPageViewModel viewModel)
	{
		_context = context;
		InitializeComponent();
		BindingContext = viewModel;

		//_context.Categorias.Add(new Modelos.Categoria { Descripcion = "test" });
		//_context.SaveChanges();

	}

	
}

