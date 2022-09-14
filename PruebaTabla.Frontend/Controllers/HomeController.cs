using Microsoft.AspNetCore.Mvc;
using PruebaTabla.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTabla.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly PruebaTablaDbContext _context;

        public IActionResult Index()
        {
            return View();  
        }

        public async Task<ActionResult> _ViewAll()
        {

            return PartialView();
        }
    }
}
