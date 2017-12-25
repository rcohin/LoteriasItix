using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoteriasItix.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Aposta()
        {
            ViewBag.Message = "Your contact page.";

            return View("~/Views/Apostas/Create.cshtml");
        }

        public ActionResult Jogos()
        {
            ViewBag.Message = "Your contact page.";

            return View("~/Views/Apostas/Index.cshtml");
        }

        public ActionResult Sortear()
        {
            ViewBag.Message = "Your contact page.";

            return View("~/Views/Sorteios/Create.cshtml");
        }
    }
}