using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrabajoPractico2.Models;
using NLog;

namespace TrabajoPractico2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Logger _logger;

        public HomeController(ILogger<HomeController> logger, Logger log)
        {
            _logger = log;
            _logger.Info("NLog injected into HomeController");
        }

        public IActionResult Index()
        {
            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult datosEmpleado(string nombre, string apellido, string fechaNac, string tel, string direc, string puesto, string fechaIngreso)
        {
            try
            {
                if (nombre != null && apellido != null && fechaNac != null && tel != null && direc != null && puesto != null && fechaIngreso != null)
                {
                    DateTime fechaNacimiento = DateTime.Parse(fechaNac);
                    DateTime fechaIng = DateTime.Parse(fechaIngreso);
                    Empleado nuevoEmpleado = new Empleado(nombre, apellido, fechaNacimiento, direc, tel, puesto, fechaIng);
                    _logger.Info("Datos ingresados: " + nombre + " " + apellido + ", " + nuevoEmpleado.Edad + " años, " + nuevoEmpleado.Antiguedad + " años en la empresa, salario de $" + nuevoEmpleado.Salario + ".");

                    return View(nuevoEmpleado);
                }
                else
                {
                    _logger.Error("Se ingresaron datos vacios.");
                    return View("error");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return View("error");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
