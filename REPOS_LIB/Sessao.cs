using CLOUD_LIB;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLOUD_REPOS_LIB
{
    public class Sessao : ISessao
    {
        private ISession Session { get; set; }

        public Sessao(ISession _session)
        {
            Session = _session;
        }
        public void CriarSessao(UtilizadorModel utilizador)
        {
            string valor = JsonConvert.SerializeObject(utilizador);
            byte[] Sessao = Encoding.ASCII.GetBytes(valor);
            Session.Set("SessaoUtilizador", Sessao);            
        }

        public void SessaoID(UtilizadorModel utilizador)
        {
            string valor = JsonConvert.SerializeObject(utilizador.ID);
            byte[] Sessao = Encoding.ASCII.GetBytes(valor);
            Session.Set("UtilizadorID", Sessao);
        }
        public void EncerrarSessao()
        {
            Session.Remove("SessaoUtilizador");
        }

        public UtilizadorModel ProcurarSessao()
        {
            byte[] SessaoOutput;
            Session.TryGetValue("SessaoUtilizador", out SessaoOutput);
            string valorOutput = Encoding.ASCII.GetString(SessaoOutput, 0, SessaoOutput.Length);            
            return JsonConvert.DeserializeObject<UtilizadorModel>(valorOutput);

        }
    }
}
