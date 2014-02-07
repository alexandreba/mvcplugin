using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketing
{    
    public class MarketingAreaRegistration : AreaRegistration 
    { 
        public override string AreaName 
        {
            get { return "Marketing"; } 
        } 

        public override void RegisterArea(AreaRegistrationContext context) 
        { 
            context.MapRoute(
                "Marketing",
                "Marketing/{controller}/{action}/{id}", 
                new { action = "Index", 
                id = UrlParameter.Optional }); 
        } 
    } 
}