using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Controllers
{
    public class ShortenedUrlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
    }
}
