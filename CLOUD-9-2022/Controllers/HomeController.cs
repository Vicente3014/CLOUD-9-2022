using CLOUD_9_2022.Models;
using CLOUD_REPOS_LIB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_9_2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessao _sessao;
        private readonly ISession session;
        
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this.session= httpContextAccessor.HttpContext.Session;
            _sessao = new Sessao(session);
        }
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
