using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class AboutController : Controller
    {
        //This controller contains a single route that functions as the landing/home page for the site, with a bunch of helpful links to elsewhere
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
