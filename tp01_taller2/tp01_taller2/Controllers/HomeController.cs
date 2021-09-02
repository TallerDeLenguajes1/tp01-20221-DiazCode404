using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tp01_taller2.Models;
using NLog;
using static tp01_taller2.Models.Api;

namespace tp01_taller2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string problema01(string num)
        {
            try
            {
                return Math.Pow(Convert.ToInt32(num),2).ToString();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return "Error_ " + e.Message.ToString();
            }
            
        }

        public string problema02(string num1, string num2)
        {
            try
            {
                return (Convert.ToInt32(num1)/Convert.ToInt32(num2)).ToString();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return "Error_ " + e.Message.ToString();
            }

        }

        public string problema03()
        {
            try
            {
                 string dato = "";
                List<Provincia> ListadoDeProvincias = Api.ConsultaApi();
                foreach (var prov in ListadoDeProvincias)
                {
                    dato += $"id: {prov.id}. Provincia: {prov.nombre} \n";
                }
                return dato;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return "Error: " + e.Message.ToString();
                
            }
        }

        public string problema04(string km, string lt)
        {
            try
            {
                return (Convert.ToDouble(km) / Convert.ToDouble(lt)).ToString();
            }
            catch (Exception e)
            {

                logger.Error(e.Message);
                return "Error: " + e.Message.ToString();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
