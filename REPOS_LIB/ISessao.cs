using CLOUD_LIB;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLOUD_REPOS_LIB
{
    public interface ISessao
    {
        void CriarSessao(UtilizadorModel utilizador);
        void EncerrarSessao();
        UtilizadorModel ProcurarSessao();
        public void SessaoID(UtilizadorModel utilizador);
    }
}
