using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plugin
{    
    public class PluginAreaRegistration : AreaRegistration 
    { 
        public override string AreaName 
        { 
             get { return "Plugin"; } 
        } 

        public override void RegisterArea(AreaRegistrationContext context) 
        { 
            context.MapRoute(
                "Plugin", 
                "Plugin/{controller}/{action}/{id}", 
                new { action = "Index", 
                id = UrlParameter.Optional }); 
        } 
    } 
}