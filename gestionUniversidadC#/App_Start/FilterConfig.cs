using gestionUniversidadC_.Filters;
using System.Web;
using System.Web.Mvc;

namespace gestionUniversidadC_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerifySession());
        }
    }
}
