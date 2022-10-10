using CLOUD_LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_REPOS_LIB
{
    public interface IUtilizadorRepositorio
    {
        UtilizadorModel Adicionar(UtilizadorModel Utilizador);
        UtilizadorModel Apagar(int id);
        UtilizadorModel ProcurarLogin(string Login);
        UtilizadorModel ProcurarPorID(int ID);
        List<UtilizadorModel> ProcurarTodos();
        UtilizadorModel Editar(UtilizadorModel Utilizador);
    }
}
