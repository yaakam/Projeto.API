using Projeto.Dominio.Enumeradores;
using System;

namespace Projeto.Dominio.ObjetosDeValor
{
    public class Mensagem: ICloneable
    {
        #region "Construtores"

        public Mensagem()
        {
        }

        public Mensagem(string Description)
        {
            this.Description = Description;
            this.Type = TipoDeMensagemEnumerador.Erro;
        }

        public Mensagem(string Description, TipoDeMensagemEnumerador Type)
        {
            this.Description = Description;
            this.Type = Type;
        }

        #endregion

        #region "Propriedades"
        public string Description { get; set; }

        public TipoDeMensagemEnumerador Type { get; set; }

        #endregion

        #region "ICloneable"
        public object Clone()
        {
            return (Mensagem)MemberwiseClone();
        }
        #endregion
    }
}
