using System;
using System.Collections.Generic;
using System.Text;
using CLOUD_LIB;

namespace CLOUD_REPOS_LIB
{
    public interface IFatura
    {
        List<FaturaModel> ProcurarTodos();
        FaturaModel Adicionar(FaturaModel Fatura, int? id);
        FaturaModel ProcurarPorID(int ID);
        List<FaturaModel> ListaFatura(int ID);
        FaturaModel Apagar(int id);

        DetalhesFatura AdicionarDetalhe(DetalhesFatura Detalhe);
        
    }
}
