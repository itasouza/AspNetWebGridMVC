using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGridUsandoAspNet.Data;

namespace WebGridUsandoAspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext database = new ApplicationDbContext();

    
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ListarCategoria()
        {
            var dados = database.Categorias.ToList();
            return View(dados);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}