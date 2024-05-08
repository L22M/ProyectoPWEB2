
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository;
using ProyectoTiendaZapatos.AccesoDatos;
using ProyectoTiendaZapatos.Models;
using System.Linq;
using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository
{
    public class DetalleVentaRepository : Repository<DetalleVenta>, IDetalleVentaRepository
    {
        private readonly ApplicationDbContext _db;

        public DetalleVentaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // Método para actualizar un detalle de venta
        public void Update(DetalleVenta detalleVenta)
        {
            var objDesdeDb = _db.DetallesVentas.FirstOrDefault(dv => dv.DetalleVentaId == detalleVenta.DetalleVentaId);
            if (objDesdeDb != null)
            {
                objDesdeDb.VentaId = detalleVenta.VentaId;
                objDesdeDb.ProductoId = detalleVenta.ProductoId;
                objDesdeDb.Cantidad = detalleVenta.Cantidad;
                objDesdeDb.Precio = detalleVenta.Precio;
                // Asumiendo que quieres actualizar toda la información de DetalleVenta.
                // Agrega aquí cualquier otro campo que necesites actualizar.

                _db.SaveChanges();
            }
        }
    }
}
