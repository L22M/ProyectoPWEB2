using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoTiendaZapatos.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICategoriaRepository Categoria { get; }
       IProductoRepository Producto { get; }
        ICompraRepository Compra { get; }
        IDetalleCompraRepository DetalleCompra { get; }
        IDetalleVentaRepository DetalleVenta { get; }
        IVentaRepository Venta { get; }

        IClienteRepository Cliente { get; }


        void Save();
    }
}