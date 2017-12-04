using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore_React.Web.Controllers.MVC
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Project's main page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// A partial view to render controls to return to main page
        /// </summary>
        /// <returns></returns>
        public PartialViewResult ReturnToIndex()
        {
            return PartialView();
        }

        public IActionResult Example()
        {
            return View();
        }
    }
}