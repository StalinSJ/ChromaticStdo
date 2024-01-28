using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ChromaticStdo.DataAcess;
using ChromaticStdo.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;


namespace ChromaticStdo.ViewsModels
{
    public partial class MisComprasViewModel : ObservableObject
    {
        private readonly ChromaticStdoDbContext _context;
        [ObservableProperty]
        ObservableCollection<CompraDTO> listaCompras = new ObservableCollection<CompraDTO>();

        public MisComprasViewModel(ChromaticStdoDbContext context)
        {
            _context = context;
        }

        public async Task ObtenerCompras()
        {

            var lista = await _context.Compras
                .Include(d => d.RefDireccion)
                .Include(t => t.RefTarjeta)
                .ToListAsync();

            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaCompras.Add(new CompraDTO
                    {
                        NumeroCompra = item.NumeroCompra,
                        Total = item.Total,
                        RefDireccion = new DireccionDTO
                        {
                            NombreDireccion = item.RefDireccion.NombreDireccion
                        },
                        RefTarjeta = new TarjetaDTO
                        {
                            NombreTarjeta = item.RefTarjeta.NombreTarjeta
                        },
                        FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy")
                    });
                }
            }


        }

    }
}
