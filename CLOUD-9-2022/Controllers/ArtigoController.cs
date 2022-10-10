using CLOUD_REPOS_LIB;
using CLOUD_LIB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_9_2022.Controllers
{
   public class ArtigoController : Controller
   {
      private readonly IArtigoRepositorio _artigoRepositorio;
      
      public ArtigoController(IArtigoRepositorio ArtigoRepositorio)
      {
          _artigoRepositorio = ArtigoRepositorio;          
      }

        public IActionResult Index()
        {
            List<ArtigoModel> artigo = _artigoRepositorio.ListarTodos();
            return View(artigo);
        }



        public IActionResult ListarTodos()
        {
            List<ArtigoModel> Artigos = new List<ArtigoModel>();
            Artigos = _artigoRepositorio.ListarTodos();
            ViewBag.Artigo = Artigos;
            return View();
        }



    }
}

