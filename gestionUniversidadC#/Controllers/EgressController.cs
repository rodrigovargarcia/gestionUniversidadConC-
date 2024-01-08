using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionUniversidadC_.Controllers
{
    public class EgressController : Controller
    {
        // GET: Egress
        public ActionResult LogOut()
        {
            Session["User"] = null;
            Session["Admin"] = null;

            return RedirectToAction("Index", "Access"); 
        }
    }
}