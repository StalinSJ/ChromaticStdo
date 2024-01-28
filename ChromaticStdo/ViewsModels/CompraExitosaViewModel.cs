using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ChromaticStdo.DataAcess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticStdo.ViewsModels
{
    public partial class CompraExitosaViewModel : ObservableObject, IQueryAttributable
    {
        private readonly ChromaticStdoDbContext _context;
        [ObservableProperty]
        public string numeroCompra;
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var numero = query["numero"].ToString();
            NumeroCompra = numero;

        }

        [RelayCommand]
        public async Task VolverBolsa()
        {
           await Shell.Current.Navigation.PopToRootAsync();
        }

        public CompraExitosaViewModel(ChromaticStdoDbContext context)
        {
            _context = context;

            _context.Carritos.ExecuteDeleteAsync();
            _context.SaveChangesAsync();
        }
    }
}
