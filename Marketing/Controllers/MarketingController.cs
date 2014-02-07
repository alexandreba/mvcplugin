using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketing.Controllers
{
    public class MarketingController : Controller
    {
        private readonly IMessageRepository _repository; 
        public MarketingController(IMessageRepository repository) 
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
