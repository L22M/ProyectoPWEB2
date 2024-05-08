using ProyectoTiendaZapatos.Data;
using ProyectoTiendaZapatos.Models;
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaProducto()
        {
            throw new NotImplementedException();
        }

        public void Update(Producto producto)
        {
            var objDesdeDb = _db.Producto.FirstOrDefault(p => p.Id == producto.Id);
            if (objDesdeDb != null)
            {
                objDesdeDb.Nombre = producto.Nombre;
                objDesdeDb.Marca = producto.Marca;
                objDesdeDb.Precio = producto.Precio;
                objDesdeDb.CategoriaId = producto.CategoriaId;
                // Si deseas actualizar también la categoría, puedes descomentar la siguiente línea:
                // objDesdeDb.Categoria = producto.Categoria;

                _db.SaveChanges();
            }

        }
    }
}
