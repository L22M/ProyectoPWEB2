
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository;
using ProyectoTiendaZapatos.AccesoDatos;
using ProyectoTiendaZapatos.Models;
using System.Linq;
using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _db;

        public ClienteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cliente cliente)
        {
            var objDesdeDb = _db.Clientes.FirstOrDefault(c => c.ClienteId == cliente.ClienteId);
            if (objDesdeDb != null)
            {
                objDesdeDb.Nombre = cliente.Nombre;
                objDesdeDb.Apellido = cliente.Apellido;
                objDesdeDb.Email = cliente.Email;
                objDesdeDb.Telefono = cliente.Telefono;
                objDesdeDb.Direccion = cliente.Direccion;
            }
            _db.SaveChanges();
        }
    }
}
