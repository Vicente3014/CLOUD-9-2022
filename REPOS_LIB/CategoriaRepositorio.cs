using CLOUD_DATA;
using CLOUD_LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_REPOS_LIB
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        
        private readonly BaseContext _baseContext;
        public CategoriaRepositorio(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public List<CategoriaModel> ProcurarTodos()
        {
            return _baseContext.Categoria.ToList();
        }        
        public CategoriaModel Adicionar(CategoriaModel Categoria)
        {
            //Inserção na Base de dados
            _baseContext.Categoria.Add(Categoria);
            _baseContext.SaveChanges();
            return Categoria;
        }

        public CategoriaModel Apagar(CategoriaModel categoria)
        {
            //Eliminar Utilizador da base de dados
            _baseContext.Categoria.Remove(categoria);
            _baseContext.SaveChanges();
            return categoria;
        }

    }
}
