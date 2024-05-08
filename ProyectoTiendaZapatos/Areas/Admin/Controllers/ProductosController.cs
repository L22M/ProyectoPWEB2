using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository.IRepository;
using ProyectoTiendaZapatos.Models;

namespace ProyectoTiendaZapatos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProductosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Producto.Add(producto);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(producto);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Producto producto = new Producto();
            producto = _contenedorTrabajo.Producto.Get(id);
            if (producto == null)
            {
                return NotFound();

            }
            return View(producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto producto)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Producto.Update(producto);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Producto.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Producto.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando producto" });
            }
            _contenedorTrabajo.Producto.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la producto" });
        }
        #endregion
    }
}
