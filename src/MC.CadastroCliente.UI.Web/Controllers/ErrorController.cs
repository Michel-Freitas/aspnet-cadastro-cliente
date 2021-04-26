using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MC.CadastroCliente.UI.Web.Controllers
{
    public class ErrorController : Controller
    {
        
        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        public ActionResult AcessDenied()
        {
            return View("AcessDenied");
        }
    }
}