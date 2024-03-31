using Microsoft.AspNetCore.Mvc;
using PAWUNED_EdgarArias_Proyecto1.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace PAWUNED_EdgarArias_Proyecto1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Proyecto1Context _context;

        public HomeController(ILogger<HomeController> logger, Proyecto1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        //procedimiento para consultar la base de datos para realizar el login

            [HttpPost]
            public IActionResult Login(string username, string password)
            {
                int? usuarioId = _context.Usuarios
                .Where(u => u.Username == username && u.Password == password)
                .Select(u => (int?)u.IdUsuario)
                .FirstOrDefault();

                if (usuarioId != null)
                {
                    var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == usuarioId);
                    
                // Usuario válido, realizar las acciones necesarias

                //variables de sesion

                var sesionid = usuarioId.ToString();
                var pesoCorp = usuario.Peso.ToString();

                if (usuario != null)
                {
                    HttpContext.Session.SetString("id", sesionid);
                    
                }

                if (pesoCorp != null)
                {
                    HttpContext.Session.SetString("peso", pesoCorp);
                }


                var sesionId2 = HttpContext.Session.GetString("id");

                System.Console.WriteLine("El valor de la variable de sesión 'id' es: " + sesionId2);
                //se requiere una variable de sesion que almacene el peso del usuario


                // Redirigir a la página principal
                Console.WriteLine("usurio encontrado" + usuario);
                Console.WriteLine("usurio con ID: " + sesionid);
                //var idusuario = usuario.IdUsuario;


                //return RedirectToAction("Index","Home");
                return RedirectToAction(actionName: "Privacy", "Home");
            }
                else
                {
                    // Usuario inválido, manejar el caso en consecuencia
                    HttpContext.Session.SetString("Error", "Error: usuario no encontrado" + username);

                // Redirigir de nuevo a la página de inicio de sesión
                //return RedirectToAction("Create", "Usuarios");
                //return RedirectToAction(default);
                return RedirectToAction(actionName: "Privacy","Home");

            }

            }//fin del procedimiento de consulta

            
        }

    
}
