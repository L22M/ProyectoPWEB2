
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository;
using ProyectoTiendaZapatos.AccesoDatos;
using ProyectoTiendaZapatos.Models;
using System.Linq;
using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        private readonly ApplicationDbContext _db;

        public CompraRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Compra compra)
        {
            var objDesdeDb = _db.Compras.FirstOrDefault(c => c.CompraId == compra.CompraId);
            if (objDesdeDb != null)
            {
                objDesdeDb.Fecha = compra.Fecha;
                objDesdeDb.Total = compra.Total;
            }
            _db.SaveChanges();
        }
    }
}
