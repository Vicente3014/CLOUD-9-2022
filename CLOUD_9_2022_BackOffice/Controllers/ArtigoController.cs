using CLOUD_REPOS_LIB;
using CLOUD_LIB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_9_2022_BackOffice.Controllers
{
    public class ArtigoController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IArtigoRepositorio _artigoRepositorio;
        public ArtigoController(IArtigoRepositorio ArtigoRepositorio, ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _artigoRepositorio = ArtigoRepositorio;
        }

        public IActionResult Index()
        {
            List<ArtigoModel> artigo = _artigoRepositorio.ListarTodos();
            return View(artigo);
        }
        [HttpGet]
        public IActionResult Adicionar()
        {
            List<CategoriaModel> Categoria = new List<CategoriaModel>();
            Categoria = _categoriaRepositorio.ProcurarTodos();
            ViewBag.Categorias = Categoria;
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(ArtigoModel Artigo)
        {
            _artigoRepositorio.Adicionar(Artigo);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(ArtigoModel Artigo)
        {
            _artigoRepositorio.Apagar(Artigo);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            ArtigoModel Artigo = _artigoRepositorio.ProcurarPorID(id);
            List<CategoriaModel> Categoria = new List<CategoriaModel>();
            Categoria = _categoriaRepositorio.ProcurarTodos();
            ViewBag.Categorias = Categoria;
            return View(Artigo);
        }
        [HttpPost]
        public IActionResult Editar(ArtigoModel Artigo)
        {
            _artigoRepositorio.Editar(Artigo);
            return RedirectToAction("Index");
        }
    }
}
