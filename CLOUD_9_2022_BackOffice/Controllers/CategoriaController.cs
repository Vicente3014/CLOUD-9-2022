using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLOUD_REPOS_LIB;
using CLOUD_LIB;
using CLOUD_DATA;

namespace CLOUD_9_2022_BackOffice.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio CategoriaRepositorio)
        {
            _categoriaRepositorio = CategoriaRepositorio;
        }
        public IActionResult Index()
        {
            List<CategoriaModel> categoria = _categoriaRepositorio.ProcurarTodos();
            return View(categoria);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(CategoriaModel Categoria)
        {
            _categoriaRepositorio.Adicionar(Categoria);
            return RedirectToAction("Index");
            
        }
        public IActionResult Apagar(CategoriaModel categoria)
        {
            _categoriaRepositorio.Apagar(categoria);
            return RedirectToAction("Index");
        }
        
        public IActionResult Lista()
        {
            List<CategoriaModel> Categoria = new List<CategoriaModel>();
            Categoria = _categoriaRepositorio.ProcurarTodos();
            return View();

        }
    }
}
