using CLOUD_LIB;
using CLOUD_REPOS_LIB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace CLOUD_9_2022.Controllers
{
    public class FaturaController : Controller
    {
        private readonly IFatura _fatura;
        private readonly ISessao _sessao;
        private readonly ISession session;
        private readonly IArtigoRepositorio _Artigo;


        public FaturaController(IFatura Fatura,IHttpContextAccessor httpContextAccessor, IArtigoRepositorio artigoRepositorio)
        {
            _fatura = Fatura;
            this.session = httpContextAccessor.HttpContext.Session;            
            _sessao = new Sessao(session);
            _Artigo = artigoRepositorio;
        }
        // GET: FaturaController
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: FaturaController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: FaturaController/Create
        public ActionResult Create(int id)
        {
            try
            {
                //Procurar Faturas por cliente
                string ID = session.GetString("UtilizadorID");
                int ProcurarID = System.Convert.ToInt32(ID);
                FaturaModel f = _fatura.ProcurarPorID(ProcurarID);
                if (f != null)
                {
                    DetalhesFatura Detalhe = new DetalhesFatura();
                    Detalhe.ArtigoID = id;
                    Detalhe.FaturaID = f.FaturaID;
                    _fatura.AdicionarDetalhe(Detalhe);
                    return RedirectToAction("Index", "Artigo");
                }
                else
                {

                    FaturaModel F = new FaturaModel();                    
                    F.ID = ProcurarID;
                    _fatura.Adicionar(F, ProcurarID);
                    DetalhesFatura Detalhe = new DetalhesFatura();
                    Detalhe.ArtigoID = id;
                    Detalhe.FaturaID = F.FaturaID;
                    ArtigoModel X = _Artigo.ProcurarPorID(id);
                    Detalhe.Preco_unit = X.Valor;
                    _fatura.AdicionarDetalhe(Detalhe);
                    //Criar Ação que faça Utilizador.Fatura, adicionar fatura ao user                                       
                    return RedirectToAction("Index", "Artigo");
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                throw;
            }
            
        }

        
       

        // GET: FaturaController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: FaturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: FaturaController/Delete/5
        public ActionResult Apagar(int id)
        {
            
            _fatura.Apagar(id);
            return RedirectToAction("ListaFatura");
        }
        

        public IActionResult ListaFatura(int ID)
        {            
            List<FaturaModel> Faturas = _fatura.ListaFatura(ID);
            return View(Faturas);
        }
        
        public IActionResult AdicionarArtigo()
        {
            
            List<ArtigoModel> Artigos = _Artigo.ListarTodos();
            return View(Artigos);
        }

        [HttpPost]
        public IActionResult CriarDetalheFatura(int FaturaID, int ArtigoID)
        {

            return View();
        }

    }
}
