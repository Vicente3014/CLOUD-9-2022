using CLOUD_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLOUD_LIB;

namespace CLOUD_REPOS_LIB
{
        public class ArtigoRepositorio : IArtigoRepositorio
        {
            private readonly BaseContext _baseContext;
            public ArtigoRepositorio(BaseContext baseContext)
            {
                _baseContext = baseContext;
            }
            public List<ArtigoModel> ListarTodos()
            {               
               return _baseContext.Artigo.ToList();
            }
            public ArtigoModel ProcurarPorID(int ID)
            {
               return _baseContext.Artigo.FirstOrDefault(x => x.ID == ID);
            }

        public ArtigoModel Adicionar(ArtigoModel Artigo)
            {
                //Inserção na Base de dados
                _baseContext.Artigo.Add(Artigo);
                _baseContext.SaveChanges();
                return Artigo;
            }
            
            public ArtigoModel Apagar(ArtigoModel Artigo)
            {
               _baseContext.Artigo.Remove(Artigo);
               _baseContext.SaveChanges();
               return Artigo;
            }
            
            public ArtigoModel Editar(ArtigoModel Artigo)
            {
               ArtigoModel ArtigoDB = ProcurarPorID(Artigo.ID);

               if (Artigo == null) throw new System.Exception("Houve um erro ao editar o artigo");

               ArtigoDB.Nome = Artigo.Nome;
               ArtigoDB.Descricao = Artigo.Descricao;
               ArtigoDB.Categoria_ID = Artigo.Categoria_ID;
               ArtigoDB.Valor = Artigo.Valor;
               ArtigoDB.Imagem = Artigo.Imagem;
               ArtigoDB.Categoria = Artigo.Categoria;

               _baseContext.Artigo.Update(ArtigoDB);
               _baseContext.SaveChanges();
               return ArtigoDB;
            }
            

        }  
    

}
