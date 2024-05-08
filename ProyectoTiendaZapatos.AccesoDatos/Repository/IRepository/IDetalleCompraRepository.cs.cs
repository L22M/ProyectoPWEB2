using ProyectoTiendaZapatos.AccesoDatos.Data.Repository.IRepository;
using ProyectoTiendaZapatos.Models;
using System.Collections.Generic;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository
{
    public interface IDetalleCompraRepository : IRepository<DetalleCompra>
    {
        void Update(DetalleCompra detalleCompra);
    }
}
