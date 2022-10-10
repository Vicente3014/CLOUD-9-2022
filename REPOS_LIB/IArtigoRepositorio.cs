using CLOUD_LIB;
using CLOUD_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLOUD_REPOS_LIB
{
    
    
        public interface IArtigoRepositorio
        {           
            List<ArtigoModel> ListarTodos();
            ArtigoModel Adicionar(ArtigoModel Artigo);
            ArtigoModel Apagar(ArtigoModel Artigo);
            ArtigoModel Editar (ArtigoModel Artigo);
            ArtigoModel ProcurarPorID(int ID);
        }
    
}
