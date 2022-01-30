using System;

namespace Projeto.Utilitarios.ORM.NHibernate
{
    public interface ISessaoGenerica: IDisposable, ICloneable
    {
        #region "Propriedades"
        bool IsTransactionActive { get; }
        bool IsConnectionActive { get; }
        bool IsSessionActive { get; }
        #endregion

        #region "Controle da transação"
        void OpenSession();
        void BeginTransaction();
        void Confirmar();
        void Desfazer();
        void Flush();
        void Clear();
        #endregion
    }
}
