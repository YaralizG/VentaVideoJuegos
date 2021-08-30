using Microsoft.AspNetCore.Mvc;
using VentaVideoJuegos.Models;
using VentaVideoJuegos.Data;
using System.Linq;

namespace VentaVideoJuegos.Controllers
{
    public class ProductoController:Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View(_context.DataProducto.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto objProducto)
        {
            _context.Add(objProducto);
            _context.SaveChanges();
            ViewData["Message"] = "Producto registrado";
            return View();
        }

        
        public IActionResult Edit(int id)
        {
            Producto objProducto = _context.DataProducto.Find(id);
            if(objProducto == null){
                return NotFound();
            }
            return View(objProducto);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("id,nombre,categoria,precio,descuento")] Producto objProducto)
        {
             _context.Update(objProducto);
             _context.SaveChanges();
              ViewData["Message"] = "Producto actualizado";
             return View(objProducto);
        }

        public IActionResult Delete(int id)
        {
            Producto objProducto = _context.DataProducto.Find(id);
            _context.DataProducto.Remove(objProducto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}