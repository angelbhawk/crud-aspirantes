using Microsoft.AspNetCore.Mvc;
using Aspirantes.Datos;
using Aspirantes.Models;

namespace Aspirantes.Controllers
{
    public class AspirantesController : Controller
    {
        AspiranteDato _AspirantesDatos = new AspiranteDato();

        public IActionResult Listar()
        {
            var oLista = _AspirantesDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(AspiranteModel oaspirante)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _AspirantesDatos.Guardar(oaspirante);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdAspirante)
        {
            var oaspirante = _AspirantesDatos.Obtener(IdAspirante);
            return View(oaspirante);
        }

        [HttpPost]
        public IActionResult Editar(AspiranteModel oAspirante)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _AspirantesDatos.Editar(oAspirante);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdAspirante)
        {
            var oaspirante = _AspirantesDatos.Obtener(IdAspirante);
            return View(oaspirante);
        }

        [HttpPost]
        public IActionResult Eliminar(AspiranteModel oAspirante)
        {
            var respuesta = _AspirantesDatos.Eliminar(oAspirante.IdAspirante);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
