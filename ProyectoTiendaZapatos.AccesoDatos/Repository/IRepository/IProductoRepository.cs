using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoTiendaZapatos.Models;
using ProyectoTiendaZapatos.AccesoDatos.Repository;
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository.IRepository;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository
{
    public interface IProductoRepository : IRepository<Producto>
    {
        void Update(Producto Producto);
        IEnumerable<SelectListItem> GetListaProducto();

    }
}
