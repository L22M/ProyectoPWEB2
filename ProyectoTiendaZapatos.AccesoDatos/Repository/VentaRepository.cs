
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository;
using ProyectoTiendaZapatos.AccesoDatos;
using ProyectoTiendaZapatos.Models;
using System.Linq;
using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        private readonly ApplicationDbContext _db;

        public VentaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Venta venta)
        {
            var objDesdeDb = _db.Ventas.FirstOrDefault(v => v.VentaId == venta.VentaId);
            if (objDesdeDb != null)
            {
                objDesdeDb.Fecha = venta.Fecha;
                objDesdeDb.Total = venta.Total;
            }
            _db.SaveChanges();
        }
    }
}
