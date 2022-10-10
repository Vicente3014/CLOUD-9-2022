using CLOUD_DATA;
using CLOUD_LIB;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLOUD_REPOS_LIB
{
    public class FaturaRepositorio : IFatura
    {
        private readonly BaseContext _baseContext;
        private readonly ISessao _sessao;
        private readonly ISession session;
        

        public FaturaRepositorio(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        public FaturaModel ProcurarPorID(int ID)
        {
            return _baseContext.Fatura.FirstOrDefault(x => x.FaturaID == ID);
        }
        public List<FaturaModel> ProcurarTodos()
        {
            return _baseContext.Fatura.ToList();
        }
        public FaturaModel Adicionar(FaturaModel Fatura, int? id)
        {
            //Inserção na Base de dados
            _baseContext.Fatura.Add(Fatura);
            UtilizadorModel U = _baseContext.Utilizador.FirstOrDefault(U => U.ID == id);            
            U.Faturas.Append(Fatura);
            _baseContext.SaveChanges();

            return Fatura;
        }
        public List<FaturaModel> ListaFatura(int ID)
        {
            return _baseContext.Fatura.Where(f => f.Utilizador.ID == ID).ToList();            
        }

        public FaturaModel Apagar(int id)
        {
            var Fatura = _baseContext.Fatura.FirstOrDefault(f => f.FaturaID == id);

            if(Fatura != null)
            {
                _baseContext.Fatura.Remove(Fatura);
                _baseContext.SaveChanges();
                
            }
            return Fatura;
        }

        public DetalhesFatura AdicionarDetalhe(DetalhesFatura Detalhe)
        {
            _baseContext.DetalhesFatura.Add(Detalhe);
            _baseContext.SaveChanges();
            return Detalhe;
        }
    }
}
