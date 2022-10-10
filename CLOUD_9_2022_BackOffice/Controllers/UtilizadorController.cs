using CLOUD_REPOS_LIB;
using CLOUD_LIB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_9_2022_BackOffice.Controllers
{
    public class UtilizadorController : Controller
    {
        private readonly IUtilizadorRepositorio _utilizadorRepositorio;
        public UtilizadorController(IUtilizadorRepositorio UtilizadorRepositorio)
        {
            _utilizadorRepositorio = UtilizadorRepositorio;
        }
        public IActionResult Apagar(int id)
        {
            _utilizadorRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            List<UtilizadorModel> utilizadores = _utilizadorRepositorio.ProcurarTodos();
            return View(utilizadores);
        }

        
    }
}
