using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository;
using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;
using ProyectoTiendaZapatos.AccesoDatos;
using ProyectoTiendaZapatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCategoria()
        {
            return _db.Categoria.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre
            }).ToList();
        }

        public void Update(Categoria categoria)
        {
            var objDesdeDb = _db.Categoria.FirstOrDefault(p => p.Id == categoria.Id);
            objDesdeDb.Nombre = categoria.Nombre;
               
                _db.SaveChanges();
            
        }
    }
}
