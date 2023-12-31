﻿using Microsoft.AspNetCore.Mvc;
using Proyecto1_MVC_AaronVillalobosArguedas.Models;
using System.Diagnostics;

namespace Proyecto1_MVC_AaronVillalobosArguedas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.IsAuthenticated = User.Identity?.IsAuthenticated;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}