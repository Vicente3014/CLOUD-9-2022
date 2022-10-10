using CLOUD_LIB;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLOUD_SESSION
{
    public interface ISessao
    {
        void CriarSessao(UtilizadorModel utilizador);
        void EncerrarSessao();
        UtilizadorModel ProcurarSessao();
    }
}
