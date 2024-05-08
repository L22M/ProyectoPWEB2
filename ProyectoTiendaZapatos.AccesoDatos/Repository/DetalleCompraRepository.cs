
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository;
using ProyectoTiendaZapatos.AccesoDatos;
using ProyectoTiendaZapatos.Models;
using System.Linq;
using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository
{
    public class DetalleCompraRepository : Repository<DetalleCompra>, IDetalleCompraRepository
    {
        private readonly ApplicationDbContext _db;

        public DetalleCompraRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DetalleCompra detalleCompra)
        {
            var objDesdeDb = _db.DetallesCompras.FirstOrDefault(dc => dc.DetalleCompraId == detalleCompra.DetalleCompraId);
            if (objDesdeDb != null)
            {
                objDesdeDb.Cantidad = detalleCompra.Cantidad;
                objDesdeDb.Precio = detalleCompra.Precio;
            }
            _db.SaveChanges();
        }
    }
}
