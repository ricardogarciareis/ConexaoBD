using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Services;
using ConexaoBD.WEB.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.MVC.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        //CRUD de acesso à Base de Dados:
        readonly ConexaoBDContexto ctx;

        public HomeController(ConexaoBDContexto _ctx)
        {
            ctx = _ctx;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
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
