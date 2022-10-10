using CLOUD_LIB;
using CLOUD_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_REPOS_LIB
{
    public class UtilizadorRepositorio : IUtilizadorRepositorio
    {
        private readonly BaseContext _baseContext;
        public UtilizadorRepositorio(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
         
        public UtilizadorModel ProcurarPorID(int ID)
        {
            return _baseContext.Utilizador.FirstOrDefault(x => x.ID == ID);
        }
        public List<UtilizadorModel> ProcurarTodos()
        {
            return _baseContext.Utilizador.ToList();
        }
        public UtilizadorModel Adicionar(UtilizadorModel Utilizador)
        {
            //Inserção na Base de dados
            _baseContext.Utilizador.Add(Utilizador);
            _baseContext.SaveChanges();
            return Utilizador;
        }
        public UtilizadorModel Apagar(int id)
        {
            //Eliminar Utilizador da base de dados
            var Utilizador = _baseContext.Utilizador.FirstOrDefault(U => U.ID == id);
            var Fatura = _baseContext.Fatura.FirstOrDefault(F => F.ID == id);
            if(Utilizador != null)
            {
                _baseContext.Utilizador.Remove(Utilizador);
                _baseContext.Fatura.Remove(Fatura);
                _baseContext.SaveChanges();
            }           
            
            return Utilizador;
        }

        public UtilizadorModel ProcurarLogin(string Login)
        {
            return _baseContext.Utilizador.FirstOrDefault(x => x.Login.ToUpper() == Login.ToUpper());
        }

        public UtilizadorModel Editar(UtilizadorModel Utilizador)
        {
            UtilizadorModel UtilizadorDB = ProcurarPorID(Utilizador.ID);

            if (Utilizador == null) throw new System.Exception("Houve um erro ao editar o utilizador");
           
            UtilizadorDB.Login = Utilizador.Login;
            UtilizadorDB.Password = Utilizador.Password;

            _baseContext.Utilizador.Update(UtilizadorDB);
            _baseContext.SaveChanges();
            return UtilizadorDB;
        }
    }
}
