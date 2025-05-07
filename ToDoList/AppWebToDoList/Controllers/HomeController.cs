using AppWebToDoList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using AppWebToDoList.Servicios;
using System.Collections.Generic;

namespace AppWebToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _servicioApi;

        public HomeController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            List<Tarea> _list = await _servicioApi.Lista();
            return View(_list);
        }

        //VA A CONTROLAR LAS FUNCIONES DE GUARDAR O EDITAR
        public async Task<IActionResult> Tarea(int id)
        {

            Tarea modelo_producto = new Tarea();

            ViewBag.Accion = "Nueva Tarea";

            if (id != 0)
            {

                ViewBag.Accion = "Editar Tarea";
                modelo_producto = await _servicioApi.Obtener(id);
            }

            return View(modelo_producto);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Tarea ob_tarea)
        {

            bool respuesta;

            if (ob_tarea.Id == 0)
            {
                respuesta = await _servicioApi.Guardar(ob_tarea);
            }
            else
            {
                respuesta = await _servicioApi.Editar(ob_tarea);
            }


            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {

            var respuesta = await _servicioApi.Eliminar(id);

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
