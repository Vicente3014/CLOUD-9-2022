using CLOUD_REPOS_LIB;
using CLOUD_LIB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CLOUD_9_2022.Controllers
{
    public class UtilizadorController : Controller
    {
        private readonly IUtilizadorRepositorio _utilizadorRepositorio;
        private readonly ISessao _sessao;
        private readonly ISession session;
        public UtilizadorController(IUtilizadorRepositorio UtilizadorRepositorio, IHttpContextAccessor httpContextAccessor)
        {
            this.session = httpContextAccessor.HttpContext.Session;
            _utilizadorRepositorio = UtilizadorRepositorio;
            _sessao = new Sessao(session);
        }

        public IActionResult Index()
        {
            //Se com sessao iniciada, redirecionar para a Home
            if(_sessao.ProcurarSessao()!= null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(UtilizadorModel utilizadorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UtilizadorModel Utilizador = _utilizadorRepositorio.ProcurarLogin(utilizadorModel.Login);

                    if(Utilizador!=null)
                    {
                        if (Utilizador.PasswordValida(utilizadorModel.Password))
                        {
                            _sessao.CriarSessao(Utilizador);
                            _sessao.SessaoID(Utilizador);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Password incorreta";
                    }
                   TempData["MensagemErro"] = $"Username e/ou Password incorretos";
                }
                return View("Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos executar o seu Login, por favor tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Sair()
        {
            _sessao.EncerrarSessao();
            return RedirectToAction("Login", "Utilizador");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registo(UtilizadorModel Utilizador)
        {
            _utilizadorRepositorio.Adicionar(Utilizador);
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            UtilizadorModel Utilizador = _utilizadorRepositorio.ProcurarPorID(id);
            return View(Utilizador);
        }
        [HttpPost]
        public IActionResult Editar(UtilizadorModel Utilizador)
        {
            _utilizadorRepositorio.Editar(Utilizador);
            return RedirectToAction("Index");
        }


    }
}
