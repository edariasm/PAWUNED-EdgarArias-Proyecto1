using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PAWUNED_EdgarArias_Proyecto1.Models;
using System.Linq;


namespace PAWUNED_EdgarArias_Proyecto1.Controllers
{
    public class EstadisticasController : Controller
    {
        private readonly Proyecto1Context _context;
        public EstadisticasController(Proyecto1Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            var userIDString = HttpContext.Session.GetString("id");

            if (int.TryParse(userIDString, out int userID)) //

               {
                // Query para obtener la suma de calorías totales del usuario actual
                var caloriasTotales = _context.RegistroDieta
                                            .Where(r => r.IdUsuario == userID)
                                            .Sum(r => r.CaloriasTotales);

                // Query para obtener la suma de calorías consumidas por actividad física del usuario actual
                var caloriasActividadFisica = _context.ActividadFisicas
                                                    .Where(a => a.IdUsuario == userID)
                                                    .Sum(a => a.ConsumoCalorico);


                
                //calculo de los km totales recorridos por el usuario actual
                var totalKilometrosCorridos = _context.ActividadFisicas
                                            .Where(a => a.IdUsuario == userID && a.TipoActividad == "Correr")
                                            .Sum(a => a.DistanciaRecorrida);

                var totalKilometrosNadados = _context.ActividadFisicas
                                            .Where(a => a.IdUsuario == userID && a.TipoActividad == "Nadar")
                                            .Sum(a => a.DistanciaRecorrida);

                

                //cantidad total de sesionde de entrenamiento del usario actual
                var totalSesionesEntrenamiento = _context.ActividadFisicas
                                            .Where(a => a.IdUsuario == userID)
                                            .Count();



                // Pasar las estadísticas a la vista

                ViewBag.Sesiones = totalSesionesEntrenamiento;
                ViewBag.CaloriasTotales = caloriasTotales;
                ViewBag.CaloriasActividadFisica = caloriasActividadFisica;
                ViewBag.DistanciaTotal = totalKilometrosCorridos;
                ViewBag.DistanciaNado = totalKilometrosNadados; 

                return View();
            }

          
            return View();
        }
        

    }
}
