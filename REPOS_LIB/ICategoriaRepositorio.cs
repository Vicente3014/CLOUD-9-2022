using CLOUD_LIB;
using CLOUD_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_REPOS_LIB
{
    public interface ICategoriaRepositorio
    {
        CategoriaModel Adicionar(CategoriaModel Categoria);
        List<CategoriaModel> ProcurarTodos();
        CategoriaModel Apagar(CategoriaModel categoria);
    }
}
