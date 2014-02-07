using System.Web.Routing;
using PlugMvc4.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlugMvc4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult LoadPlugin()
        {
            try
            {
                NinjectWebCommon.RegisterServicesSpecific();                
            }
            catch (Exception ex)
            {                
                //throw ex;
            }            
            return View();
        }

    }
}
