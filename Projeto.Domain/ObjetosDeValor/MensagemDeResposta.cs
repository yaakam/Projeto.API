using System.Collections.Generic;

namespace Projeto.Dominio.ObjetosDeValor
{
    public class MensagemDeResposta
    {
        public MensagemDeResposta()
        {
            Mensagens = new List<Mensagem>();
        }

        public bool Status { get; set; }
        public object Dados { get; set; }
        public IList<Mensagem> Mensagens { get; set; }
    }
}
