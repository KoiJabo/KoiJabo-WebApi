using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace koi_jabo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }       

        public ActionResult Restaurant()
        {
            var req = Request.QueryString;
            return View();
        }
    }
}