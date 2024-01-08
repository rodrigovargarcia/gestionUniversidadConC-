using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionUniversidadC_;
using gestionUniversidadC_.Controllers;
using gestionUniversidadC_.Models;

namespace gestionUniversidadC_.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (usuario)HttpContext.Current.Session["User"];
            var oAdmin = (usuario)HttpContext.Current.Session["Admin"];
            if (oUser == null && oAdmin == null)
            {
                if(filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }


            base.OnActionExecuting(filterContext);
        }
    }
}