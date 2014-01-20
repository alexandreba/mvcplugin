using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plugin.Controllers
{
    public class PluginController : Controller
    {
        private readonly IMessageRepository _repository; 
        public PluginController(IMessageRepository repository) 
        { 
            _repository = repository; 
        } 

        public ActionResult Index() 
        { 
            var message = _repository.Message(); 
            ViewBag.Message = message; 
            return View(); 
        } 
    }
}
