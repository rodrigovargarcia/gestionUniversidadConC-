using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionUniversidadC_.Models;


namespace gestionUniversidadC_.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (gestion_universidadEntities db = new gestion_universidadEntities())
                {
                    var lst = from d in db.usuario
                              where d.email == user && d.password == password
                              select d;
                    if (lst.Count() > 0)
                    {
                        usuario oUser = lst.First();
                        if (oUser.administrador == true)
                        {
                            Session["Admin"] = oUser;
                            return Content("1");
                        }
                        else 
                        {
                            Session["User"] = oUser;
                            return Content("1");
                        }
                    }
                    else
                    {
                        return Content("Usuario inválido :(");
                    }
                } 

            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);                
            }
        }        
    }
}