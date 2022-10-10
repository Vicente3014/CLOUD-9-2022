using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLOUD_LIB;
using CLOUD_REPOS_LIB;
using Newtonsoft.Json;

namespace CLOUD_9_2022_BackOffice.Controllers
{
    public class FaturaController : Controller
    {
        private readonly IFatura _faturaRepositorio;
        private readonly IUtilizadorRepositorio _utilizadorRepositorio;

        public FaturaController(IFatura Fatura)
        {
            _faturaRepositorio = Fatura;
        }
        public IActionResult Index()
        {
            List<FaturaModel> Fatura = _faturaRepositorio.ProcurarTodos();
            return View(Fatura);
        }

        public IActionResult Apagar(int id)
        {
            _faturaRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
        


    }
}
