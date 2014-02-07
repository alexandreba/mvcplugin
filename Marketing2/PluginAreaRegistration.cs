using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketing2
{    
    public class Marketing2AreaRegistration : AreaRegistration 
    { 
        public override string AreaName 
        { 
             get { return "Marketing2"; } 
        } 

        public override void RegisterArea(AreaRegistrationContext context) 
        { 
            context.MapRoute(
                "Marketing2", 
                "Marketing2/{controller}/{action}/{id}", 
                new { action = "Index", 
                id = UrlParameter.Optional }); 
        } 
    } 
}