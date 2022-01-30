using Projeto.Dominio.Enumeradores;
using Projeto.Dominio.ObjetosDeValor;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Dominio.Extensoes
{
    public static class MensagensExtensao
    {
        public static bool TemErros(this IList<Mensagem> messages)
        {
            return messages != null && messages.Any(F => F.Type == TipoDeMensagemEnumerador.Erro) ? true : false;
        }

        public static void RemoveMensagensDuplicadas(this List<Mensagem> messages)
        {
            var newErrorList = (from i in messages
                                select i).Distinct(new ComparadorDeMensagens()).ToList();

            messages.Clear();
            messages.AddRange(newErrorList);
        }

        private class ComparadorDeMensagens : IEqualityComparer<Mensagem>
        {
            public bool Equals(Mensagem x, Mensagem y)
            {
                return
                    x.Type == TipoDeMensagemEnumerador.Erro &&
                    x.Description.Equals(y.Description);
            }

            public int GetHashCode(Mensagem obj)
            {
                return (obj.Type + obj.Description).GetHashCode();
            }
        }
    }    
}
